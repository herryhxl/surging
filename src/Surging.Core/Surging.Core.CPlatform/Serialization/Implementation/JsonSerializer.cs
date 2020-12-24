using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Surging.Core.CPlatform.Serialization.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Surging.Core.CPlatform.Serialization.Implementation
{
    /// <summary>
    /// Json序列化器。
    /// </summary>
    public sealed class JsonSerializer : ISerializer<string>
    {
        private readonly ILogger<JsonSerializer> _logger;
        private readonly JsonSerializerOptions _options;
        public JsonSerializer(ILogger<JsonSerializer> logger, IOptions<JsonSerializerOptions> options)
        {
            _logger = logger;
            _options = options.Value;
            if (_options == null) _options = new JsonSerializerOptions();
            if (!_options.PropertyNameCaseInsensitive) _options.PropertyNameCaseInsensitive = true;
            _options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            _options.WriteIndented = true;
            if (_options.Converters == null || !_options.Converters.Any())
            {
                _options.Converters.Add(new DateTimeJsonConverter());
                _options.Converters.Add(new DateTimeNullJsonConverter());
            }
        }
        #region Implementation of ISerializer<string>

        /// <summary>
        /// 序列化。
        /// </summary>
        /// <param name="instance">需要序列化的对象。</param>
        /// <returns>序列化之后的结果。</returns>
        public string Serialize(object instance)
        {
            return System.Text.Json.JsonSerializer.Serialize(instance, _options);//JsonConvert.SerializeObject(instance);
        }

        /// <summary>
        /// 反序列化。
        /// </summary>
        /// <param name="content">序列化的内容。</param>
        /// <param name="type">对象类型。</param>
        /// <returns>一个对象实例。</returns>
        public object Deserialize(string content, Type type)
        {
            return System.Text.Json.JsonSerializer.Deserialize(content, type, _options);// JsonConvert.DeserializeObject(content, type);
        }
        #endregion Implementation of ISerializer<string>
    }
}