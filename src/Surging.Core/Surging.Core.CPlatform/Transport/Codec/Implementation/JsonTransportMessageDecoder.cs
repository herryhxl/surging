using Surging.Core.CPlatform.Messages;
using System.Text;
using System.Text.Json;

namespace Surging.Core.CPlatform.Transport.Codec.Implementation
{
    public sealed class JsonTransportMessageDecoder : ITransportMessageDecoder
    {
        #region Implementation of ITransportMessageDecoder

        public TransportMessage Decode(byte[] data)
        {
            var content = Encoding.UTF8.GetString(data);
            var message = JsonSerializer.Deserialize<TransportMessage>(content);
            if (message.IsInvokeMessage())
            {
                message.Content = JsonSerializer.Deserialize<RemoteInvokeMessage>(message.Content.ToString());
            }
            if (message.IsInvokeResultMessage())
            {
                message.Content = JsonSerializer.Deserialize<RemoteInvokeResultMessage>(message.Content.ToString());
            }
            return message;
        }

        #endregion Implementation of ITransportMessageDecoder
    }
}