using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Surging.Models.Common.Models
{
    [ProtoContract]
    public class RequestLongModel
    {
        [ProtoMember(1)]
        public long Id { set; get; }
    }
}
