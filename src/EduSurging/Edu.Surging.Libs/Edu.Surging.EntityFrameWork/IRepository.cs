using Edu.Surging.Models.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edu.Surging.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="T"></typeparam>
    public partial interface IRepository<TEntity,T>:IService<TEntity, T> where TEntity : BaseEntity<T>
    {
        #region 基础方法
        TEntity MapToEntity(object intput);
        O MapToViewModel<O>(TEntity intput) where O : class;
        O MapTo<I, O>(I intput) where I : class where O : class;
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
        #endregion
        /// <summary>
        /// 需要自行处理过滤表达式
        /// </summary>
        /// <typeparam name="ViewModel"></typeparam>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        /// <param name="orderBy"></param>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <param name="tracking"></param>
        /// <returns></returns>
        Task<PageList<ViewModel>> PageSearchAsync<ViewModel>(BaseCondition condition, Expression<Func<TEntity, bool>> expression = null, Expression<Func<ViewModel, object>> orderBy = null, IQueryable<TEntity> query = null, List<Expression<Func<TEntity, object>>> includes = null, bool tracking = true)
            where ViewModel : BaseEntity<T>;
        Expression<Func<TEntity, bool>> Express(T keyValue);
        #region Properties
        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        #endregion
    }
}