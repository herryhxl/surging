using Edu.Surging.EntityFramework.Extend;
using Edu.Surging.Models.Common.Models;
using Microsoft.EntityFrameworkCore;
using Surging.Core.CPlatform.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Surging.EntityFramework
{
    public abstract class BaseService<TEntity, T, TRepository, TChange> : Service<TEntity, T, TRepository>, IBaseService<TEntity, T> where TEntity : BaseEntity<T> where TRepository : IRepository<TEntity, T> where TChange : IChangeService<TEntity, T>
    {
        public readonly TChange _changeService;
        public BaseService(TRepository repository, TChange changeService, IWorkContext workContext) : base(repository, workContext)
        {
            _changeService = changeService;
        }
        /// <summary>
        /// 根据指定的搜索模型，返回查询表达式和排序表达式
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public abstract Tuple<Expression<Func<TEntity, bool>>, Expression<Func<TEntity, object>>, TSearch> SearchByCondition<ViewModel, TSearch>(TSearch condition, Expression<Func<TEntity, object>> orderBy = null) where ViewModel : BaseEntity<T>
            where TSearch : BaseCondition;

        #region 自定义公共方法
        /// <summary>
        /// 创建或更新数据
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        public virtual Task<TEntity> CreateOrModifyAsync<ViewModel>(ViewModel viewModel, Expression<Func<TEntity, bool>> expression = null, List<Expression<Func<TEntity, object>>> includes = null) where ViewModel : BaseEntity<T>
        {
            TEntity entity;
            if (viewModel is TEntity mentity)
                entity = mentity;
            else
                entity = _repository.MapToEntity(viewModel);
            _repository.AttachEntity(entity);
            return Task.FromResult(entity);
        }

        public Task<PageList<ViewModel>> PageConditionAsync<ViewModel, TSearch>(TSearch condition, Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, object>> orderBy = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
            where ViewModel : BaseEntity<T> where TSearch : BaseCondition
        {
            var pagePara = SearchByCondition<ViewModel, TSearch>(condition, orderBy);
            var pageQuery = _repository.Where(expression == null ? pagePara.Item1 : expression.And(pagePara.Item1), query, includes, tracking);
            var pageOrderBy = pagePara.Item2 == null ? orderBy = r => r.Id : pagePara.Item2;
            var result = pagePara.Item3.IsDescending ? pageQuery.OrderByDescending(pageOrderBy) : pageQuery.OrderBy(pageOrderBy);
            return _repository.Where<ViewModel>(null, result).ToPage(pagePara.Item3);
        }
        /// <summary>
        /// 批量删除并返回删除条数
        /// </summary>
        /// <param name="request"></param>
        /// <param name="expression"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual async Task Delete(RequestBeach<T> request, Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null)
        {
            if (request == null || request.List == null || !request.List.Any()) throw new ValidateException("参数不能为空。");
            Expression<Func<TEntity, bool>> deleteExpress = r => request.List.Contains(r.Id);
            if (expression != null) deleteExpress = deleteExpress.And(expression);
            //查询根据权限可实际删除数据
            var deleteList = await _repository.Where(expression, query).ToListAsync();
            if (!deleteList.Any()) throw new ValidateException("数据不存在或无权限。");
            if (deleteList.Count != request.List.Count) throw new ValidateException("部分数据不存在或无权限，请刷新后再试。");
            deleteList.ForEach(item =>
            {
                _changeService.Delete(item);
                _repository.Delete(item);
            });
        }
        /// <summary>
        /// 创建或更新数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        public virtual void CreateOrModify(TEntity entity, Expression<Func<TEntity, bool>> expression = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            _repository.AttachEntity(entity);
        }
        /// <summary>
        /// 批量删除并返回删除条数
        /// </summary>
        /// <param name="request"></param>
        /// <param name="expression"></param>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual async Task<int> DeleteAsync(RequestBeach<T> request, Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            if (request.List == null || request.List.Count == 0) throw new ValidateException("未包含任何删除的元素");
            Expression<Func<TEntity, bool>> deleteEx = r => request.List.Contains(r.Id);
            Expression<Func<TEntity, bool>> queryEx = expression == null ? deleteEx : expression.And(deleteEx);
            //查询根据权限可实际删除数据
            var deleteRecords = await _repository.Where(queryEx, query, includes).ToListAsync();
            if (!deleteRecords.Any()) throw new ValidateException("数据不存在或无权限。");
            if (deleteRecords.Count() != request.List.Count) throw new ValidateException("部分删除元素不存在或无权限操作。");
            deleteRecords.ForEach(item =>
            {
                _changeService.Delete(item);
                _repository.Delete(item);
            });
            return request.List.Count();
        }
        /// <summary>
        /// 根据指定字段批量更新数据记录
        /// </summary>
        /// <param name="request"></param>
        /// <param name="expression"></param>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual async Task<int> BeachOperationAsync(RequestBeachModel<T> request, Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            if (request == null || request.List == null || request.List.Count == 0) throw new ValidateException("未包含任何删除的元素");
            Expression<Func<TEntity, bool>> upatesEx = r => request.List.Contains(r.Id);
            Expression<Func<TEntity, bool>> queryEx = expression == null ? upatesEx : expression.And(upatesEx);
            //查询根据权限可实际删除数据
            var updateRecords = await _repository.Where(queryEx, query, includes).ToListAsync();
            if (!updateRecords.Any()) throw new ValidateException("数据不存在或无权限。");
            if (updateRecords.Count() != request.List.Count) throw new ValidateException("部分元素不存在或无权限操作。");
            updateRecords.ForEach(item =>
            {
                UpdateFieldValue(item, request.FieldName, request.Value);
                _changeService.Update(item);
            });
            return request.List.Count();
        }
        public virtual void UpdateFieldValue(TEntity entity, string fiedName, string value)
        {
            throw new ValidateException("方法未实现,请重写该方法");
        }
        public Task<ViewModel> InfoAsync<ViewModel>(RequestModel<T> request, Expression<Func<TEntity, bool>> expression = null) where ViewModel : class
        {
            if (request == null || request.Id == null) throw new ValidateException("参数不能为空");
            Expression<Func<TEntity, bool>> searchEx = _repository.Express(request.Id);
            return FirstOrDefaultAsync<ViewModel>(expression == null ? searchEx : expression.And(searchEx));
        }
        #endregion
    }
}
