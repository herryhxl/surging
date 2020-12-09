using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EFRepository.Extend;

namespace EFRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="T"></typeparam>
    public abstract class EfRepository<TEntity,T> : IRepository<TEntity,T> where TEntity : BaseEntity<T>
    {
        #region Fields
        private readonly IDbContext _context;
        private DbSet<TEntity> _entities; 
        public readonly IMapper _mapper;
        public readonly ILogger<EfRepository<TEntity,T>> _logger;
        #endregion
        #region Ctor
        public EfRepository(IDbContext context, IMapper mapper, ILogger<EfRepository<TEntity, T>> logger)
        {
            _context = context;
            _logger = logger; 
            _mapper = mapper;
        }
        #endregion
        
        #region 基础方法
        public Task<ViewModel> FirstOrDefaultAsync<ViewModel>(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null) where ViewModel : class
        {
            return Where<ViewModel>(expression, query, includes, false).FirstOrDefaultAsync();
        }
        public O MapTo<I, O>(I intput) where I : class where O : class
        {
            return _mapper.Map<I, O>(intput);
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
            return Where(expression, query, includes, tracking).ProjectTo<TModel>(_mapper.ConfigurationProvider);
        }
        #endregion

        #region 自定义公共方法
        public Task<PageList<ViewModel>> PageSearchAsync<ViewModel>(BaseCondition condition, Expression<Func<TEntity, bool>> expression = null, Expression<Func<ViewModel, object>> orderBy = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
            where ViewModel : BaseEntity<T>
        {
            var pageQuery = Where<ViewModel>(expression, query, includes, tracking);
            if (orderBy == null) orderBy = r => r.Id;
            pageQuery = condition.IsDescending ? pageQuery.OrderByDescending(orderBy) : pageQuery.OrderBy(orderBy);
            return pageQuery.ToPage(condition);
        }
        public virtual Expression<Func<TEntity, bool>> Express(T keyValue)
        {
            //Expression<Func<TEntity, bool>> search = r => r.Id == value;
            throw new ValidateException("方法未实现,请重写该方法");
        }
        #endregion

        #region Utilities
        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Add(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Remove(entity);
        }
        public void AttachDelete(TEntity entity)
        {
            AttachEntity(entity);
            Entities.Remove(entity);
        }
        public void AttachEntity(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Entities.Attach(entity);
        }
        #region 事务处理
        private IDbContextTransaction trans = null;
        public void BeginTransaction(IsolationLevel level = IsolationLevel.ReadUncommitted)
        {
            var efDbContext = ((DbContext)_context);
            trans = efDbContext.Database.BeginTransaction(level);
        }
        public void EndTransaction()
        {
            if (trans == null) throw new Exception("请开始一个事务。");
            trans.Commit();
            trans.Dispose();
            trans = null;
        }
        #endregion 事务处理
        public Task<int> SaveChangesAsync()
        {
            var efDbContext = (DbContext)_context;
            return efDbContext.SaveChangesAsync();
        }
        public int SaveChanges()
        {
            var efDbContext = (DbContext)_context;
            return efDbContext.SaveChanges();
        }
        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
        {
            return Where(expression, query, includes, tracking).FirstOrDefaultAsync();
        }
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
        {
            if (query == null)
                query = Entities;
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (includes != null && includes.Any())
            {
                includes.ForEach(item =>
                {
                    query = query.Include(item);
                });
            }
            return expression == null ? query : query.Where(expression);
        }

        #region 基础方法
        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            return Where(expression, query, includes, true).FirstOrDefaultAsync();
        }
        #endregion
        #endregion
        #region Properties
        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;
        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();
        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity,T>();
                return _entities;
            }
        }
        #endregion
    }
}