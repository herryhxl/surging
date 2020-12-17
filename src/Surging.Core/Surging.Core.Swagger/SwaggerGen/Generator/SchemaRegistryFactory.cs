using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Surging.Core.CPlatform;

namespace Surging.Core.SwaggerGen
{
    public class SchemaRegistryFactory : ISchemaRegistryFactory
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly SchemaRegistryOptions _schemaRegistryOptions;

        public SchemaRegistryFactory(IOptions<SchemaRegistryOptions> schemaRegistryOptionsAccessor)
        {

            _schemaRegistryOptions = schemaRegistryOptionsAccessor.Value;

        }
        public ISchemaRegistry Create(JsonSerializerSettings jsonSerializerSettings)
        {
            return new SchemaRegistry(jsonSerializerSettings, _schemaRegistryOptions);
        }
    }
}
