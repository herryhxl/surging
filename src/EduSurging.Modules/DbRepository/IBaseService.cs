using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository
{
    public interface IBaseService<TEntity, K>: IService<TEntity, K> where TEntity : BaseEntity<K>
    {
        TEntity MapToEntity(object intput);
        T MapToViewModel<T>(TEntity intput) where T : class;
        /// <summary>
        /// 处理为指定的Model,需要先配置好AutoMapper相关映射
        /// </summary>
        /// <typeparam name="ViewModel">视图模型</typeparam>
        /// <param name="expression"></param>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <param name="tracking"></param>
        /// <returns></returns>
        IQueryable<ViewModel> Where<ViewModel>(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true) where ViewModel : class;
        /// <summary>
		/// 根据主键获取Model信息
		/// </summary>
		Task<ViewModel> FirstOrDefaultAsync<ViewModel>(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null) where ViewModel : class;
  
        Tuple<Expression<Func<TEntity, bool>>, Expression<Func<TEntity, object>>, TSearch> SearchByCondition<ViewModel, TSearch>(TSearch condition, Expression<Func<TEntity, object>> orderBy = null) where ViewModel : BaseEntity<K>
            where TSearch : BaseCondition;
        void UpdateFieldValue(TEntity entity, string fiedName, string value);
        /// <summary>
        /// 通用分页,需自行重写SearchByCondition返回查询表达式及排序表达式
        /// </summary>
        /// <typeparam name="ViewModel">视图模型</typeparam>
        /// /// <typeparam name="TSearch">搜索模型</typeparam>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        /// <param name="orderBy"></param>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <param name="tracking"></param>
        /// <returns></returns>
        Task<PageList<ViewModel>> PageConditionAsync<ViewModel, TSearch>(TSearch condition, Expression<Func<TEntity, bool>> expression = null, Expression<Func<TEntity, object>> orderBy = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
            where ViewModel : BaseEntity<K> where TSearch : BaseCondition;
        Task<PageList<ViewModel>> PageSearchAsync<ViewModel>(BaseCondition condition, Expression<Func<TEntity, bool>> expression = null, Expression<Func<ViewModel, object>> orderBy = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
            where ViewModel : BaseEntity<K>;
        /// <summary>
		/// 新增或编辑
		/// </summary>
		Task<TEntity> CreateOrModifyAsync<ViewModel>(ViewModel entity, Expression<Func<TEntity, bool>> expression = null, List<Expression<Func<TEntity, object>>> includes = null) where ViewModel : BaseEntity<K>;

        Task<ViewModel> InfoAsync<ViewModel>(RequestModel<K> request, Expression<Func<TEntity, bool>> expression = null) where ViewModel : class;
        /// <summary>
        /// 批量更新字段值
        /// </summary>
        Task<int> BeachOperationAsync(RequestBeachModel<K> request, Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null);
        /// <summary>
		/// 批量删除
		/// </summary>
		Task<int> DeleteAsync(RequestBeach<K> request, Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null);
    }
}
