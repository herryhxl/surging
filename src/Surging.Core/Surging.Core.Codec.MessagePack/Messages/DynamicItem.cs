using MessagePack;
using Surging.Core.Codec.MessagePack.Utilities;
using Surging.Core.CPlatform.Utilities;
using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;

namespace Surging.Core.Codec.MessagePack.Messages
{
    [MessagePackObject]
    public class DynamicItem
    {
        #region Constructor

        public DynamicItem()
        { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DynamicItem(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var valueType = value.GetType();
            var code = Type.GetTypeCode(valueType);

            if (code != TypeCode.Object && valueType.BaseType!=typeof(Enum))
                TypeName = valueType.FullName;
            else
                TypeName = valueType.AssemblyQualifiedName;
            if (valueType == UtilityType.JObjectType || valueType == UtilityType.JArrayType|| valueType == typeof(JsonElement))
                Content = SerializerUtilitys.Serialize(value.ToString());
            else if(valueType != typeof(CancellationToken))
                Content = SerializerUtilitys.Serialize(value);
        }

        #endregion Constructor

        #region Property

        [Key(0)]
        public string TypeName { get; set; }

        [Key(1)]
        public byte[] Content { get; set; }
        #endregion Property

        #region Public Method
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Get()
        {
            if (Content == null || TypeName == null)
                return null;

            var typeName = Type.GetType(TypeName);
            if(typeName == null)
            {
                return  SerializerUtilitys.Deserialize<object>(Content);
            }
            else if (typeName == UtilityType.JObjectType || typeName == UtilityType.JArrayType)
            {
                var content = SerializerUtilitys.Deserialize<string>(Content);
                return JsonSerializer.Deserialize(content, typeName);
            }
            else if(typeName == typeof(JsonElement))
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
