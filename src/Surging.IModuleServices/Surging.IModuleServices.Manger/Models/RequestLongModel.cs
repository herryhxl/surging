﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace Surging.IModuleServices.Manager.Models
{
    [ProtoContract]
    public class RequestLongModel
    {
        [ProtoMember(1)]
        public long Id { set; get; }
    }
}
