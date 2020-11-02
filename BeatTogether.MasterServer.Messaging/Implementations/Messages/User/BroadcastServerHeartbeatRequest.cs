﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatTogether.MasterServer.Messaging.Abstractions;
using BeatTogether.MasterServer.Messaging.Extensions;
using Krypton.Buffers;

namespace BeatTogether.MasterServer.Messaging.Implementations.Messages.User
{
    public class BroadcastServerHeartbeatRequest : IMessage
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Secret { get; set; }
        public uint CurrentPlayerCount { get; set; }

        public void WriteTo(GrowingSpanBuffer buffer)
        {
            buffer.WriteString(UserId);
            buffer.WriteString(UserName);
            buffer.WriteString(Secret);
            buffer.WriteVarUInt(CurrentPlayerCount);
        }

        public void ReadFrom(SpanBufferReader bufferReader)
        {
            UserId = bufferReader.ReadString();
            UserName = bufferReader.ReadString();
            Secret = bufferReader.ReadString();
            CurrentPlayerCount = bufferReader.ReadVarUInt();
        }
    }
}
