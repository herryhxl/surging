

namespace Edu.Surging.EntityFramework
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="K"></typeparam>
    public interface IChangeService<TEntity,K> where TEntity : BaseEntity<K>
    {
        /// <summary>
        /// 新增完成后续操作
        /// </summary>
        void Add(TEntity entity);
        /// <summary>
        /// 编辑完成后续操作
        /// </summary>
        void Update(TEntity entity);
        /// <summary>
        /// 字段更新操作
        /// </summary>
        bool UpdateField<T>(TEntity entity, T OldValue, string FieldName, T Value);
        /// <summary>
        /// 模型删除操作
        /// </summary>
        void Delete(TEntity entity);
    }
}