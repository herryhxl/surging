using Edu.Surging.Models.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Edu.Surging.EntityFramework
{
    public interface IService<TEntity, T> where TEntity : BaseEntity<T>
    {
        #region Methods
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void AttachDelete(TEntity entity);
        void AttachEntity(TEntity entity);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true);
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <param name="level"></param>
        void BeginTransaction(IsolationLevel level = IsolationLevel.ReadUncommitted);
        /// <summary>
        /// 结束事务
        /// </summary>
        void EndTransaction();
        /// <summary>
        /// 异步提交保存
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
        int SaveChanges();
        #endregion
    }
}
