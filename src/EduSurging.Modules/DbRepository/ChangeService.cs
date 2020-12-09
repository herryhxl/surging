using EFRepository.Extend;
using Microsoft.Extensions.Logging;

namespace EFRepository
{
    public class ChangeService<TEntity, K> : IChangeService<TEntity,K> where TEntity : BaseEntity<K>
    {
        private readonly ILogger<ChangeService<TEntity, K>> _logger;
        public ChangeService(ILogger<ChangeService<TEntity, K>> logger)
        {
            _logger = logger;
        }
        public virtual void Add(TEntity entity)
        {

        }
        public virtual void Update(TEntity entity)
        {

        }

        public virtual void Delete(TEntity entity)
        {

        }
        public virtual bool UpdateField<T>(TEntity entity, T OldValue, string FieldName, T Value)
        {
            return OldValue.IsChange(Value);
        }
    }
}
