﻿using BeatTogether.MasterServer.Messaging.Abstractions.Messages;
using BeatTogether.MasterServer.Messaging.Extensions;
using BeatTogether.MasterServer.Messaging.Implementations.Messages.Models;
using Krypton.Buffers;

namespace BeatTogether.MasterServer.Messaging.Implementations.Messages.User
{
    public class ConnectToMatchmakingRequest : BaseMessage, IReliableRequest, IEncryptedMessage
    {
        public uint SequenceId { get; set; }
        public uint RequestId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public byte[] Random { get; set; }
        public byte[] PublicKey { get; set; }
        public GameplayServerConfiguration Configuration { get; set; }
        public string Secret { get; set; }

        public override void WriteTo(ref GrowingSpanBuffer buffer)
        {
            buffer.WriteString(UserId);
            buffer.WriteString(UserName);
            buffer.WriteBytes(Random);
            buffer.WriteVarBytes(PublicKey);
            Configuration.WriteTo(ref buffer);
            buffer.WriteString(Secret);
        }

        public override void ReadFrom(ref SpanBufferReader bufferReader)
        {
            UserId = bufferReader.ReadString();
            UserName = bufferReader.ReadString();
            Random = bufferReader.ReadBytes(32).ToArray();
            PublicKey = bufferReader.ReadVarBytes().ToArray();
            Configuration = new GameplayServerConfiguration();
            Configuration.ReadFrom(ref bufferReader);
            Secret = bufferReader.ReadString();
        }
    }
}
