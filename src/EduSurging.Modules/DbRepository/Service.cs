using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Surging.EntityFramework
{
    public class Service<TEntity, T, TRepository> : IService<TEntity, T> where TEntity : BaseEntity<T> where TRepository : IRepository<TEntity, T>
    {
        public readonly IWorkContext _workContext;
        public readonly TRepository _repository;
        public Service(TRepository repository, IWorkContext workContext)
        {
            _repository = repository;
            _workContext = workContext;
        }
        public void AttachDelete(TEntity entity)
        {
            _repository.AttachDelete(entity);
        }

        public void AttachEntity(TEntity entity)
        {
            _repository.AttachEntity(entity);
        }

        public void BeginTransaction(IsolationLevel level = IsolationLevel.ReadUncommitted)
        {
            _repository.BeginTransaction(level);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void EndTransaction()
        {
            _repository.EndTransaction();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
        {
            return _repository.FirstOrDefaultAsync(expression, query, includes, tracking);
        }

        public TEntity GetById(object id)
        {
            return _repository.GetById(id);
        }

        public void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }

        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _repository.SaveChangesAsync();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
        {
            return _repository.Where(expression, query, includes, tracking);
        }

        public Task<ViewModel> FirstOrDefaultAsync<ViewModel>(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null) where ViewModel : class
        {
            return Where<ViewModel>(expression, query, includes, false).FirstOrDefaultAsync();
        }
        public O MapTo<I, O>(I intput) where I : class where O : class
        {
            return _repository.MapTo<I, O>(intput);
        }
        public TEntity MapToEntity(object intput)
        {
            return MapTo<object, TEntity>(intput);
        }
        public O MapToViewModel<O>(TEntity intput) where O : class
        {
            return MapTo<TEntity, O>(intput);
        }
        public IQueryable<TModel> Where<TModel>(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true) where TModel : class
        {
            return _repository.Where<TModel>(expression, query, includes, tracking);
        }
        public Task<PageList<ViewModel>> PageSearchAsync<ViewModel>(BaseCondition condition, Expression<Func<TEntity, bool>> expression = null, Expression<Func<ViewModel, object>> orderBy = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
            where ViewModel : BaseEntity<T>
        {
            return _repository.PageSearchAsync(condition, expression, orderBy, query, includes, tracking);
        }
    }
}
