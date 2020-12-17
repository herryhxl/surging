using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Surging.Core.Swagger
{
    public class SwaggerSerializerFactory
    {
        public static JsonSerializer Create(JsonSerializerSettings jsonSerializerSettings)
        {
            return new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = jsonSerializerSettings.Formatting,
                ContractResolver = new SwaggerContractResolver(jsonSerializerSettings)
            };
        }
    }
}
