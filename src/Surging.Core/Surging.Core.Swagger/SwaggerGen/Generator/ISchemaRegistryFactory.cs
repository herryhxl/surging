using Newtonsoft.Json;

namespace Surging.Core.SwaggerGen
{
    public interface ISchemaRegistryFactory
    {
        ISchemaRegistry Create(JsonSerializerSettings jsonSerializerSettings);
    }
}
