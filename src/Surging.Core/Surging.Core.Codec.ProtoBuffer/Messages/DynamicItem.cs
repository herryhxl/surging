using ProtoBuf;
using Surging.Core.Codec.ProtoBuffer.Utilities;
using Surging.Core.CPlatform.Utilities;
using System;
using System.Text.Json;

namespace Surging.Core.Codec.ProtoBuffer.Messages
{
    [ProtoContract]
    public class DynamicItem
    {
        #region Constructor

        public DynamicItem()
        {
        }

        public DynamicItem(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var valueType = value.GetType();
            var code = Type.GetTypeCode(valueType);

            if (code != TypeCode.Object)
                TypeName = valueType.FullName;
            else
                TypeName = valueType.AssemblyQualifiedName;
            if (valueType == UtilityType.JObjectType || valueType == UtilityType.JArrayType || valueType == typeof(JsonElement))
                Content = SerializerUtilitys.Serialize(value.ToString());
            else
                Content = SerializerUtilitys.Serialize(value);
        }

        #endregion Constructor

        #region Property

        [ProtoMember(1)]
        public string TypeName { get; set; }
        [ProtoMember(2)]
        public byte[] Content { get; set; }
        #endregion Property

        #region Public Method
        public object Get()
        {
            if (Content == null || TypeName == null)
                return null;
            var typeName = Type.GetType(TypeName);
            if (typeName == UtilityType.JObjectType || typeName == UtilityType.JArrayType)
            {
                var content = SerializerUtilitys.Deserialize<string>(Content);
                return JsonSerializer.Deserialize(content, typeName);
            }
            else if (typeName == typeof(JsonElement))
            {
                return SerializerUtilitys.Deserialize<string>(Content);
            }
            else
            {
                return SerializerUtilitys.Deserialize(Content, typeName);
            }

        }
        #endregion Public Method
    }
}