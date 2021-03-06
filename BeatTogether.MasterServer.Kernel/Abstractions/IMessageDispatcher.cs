﻿using System.Threading;
using System.Threading.Tasks;
using BeatTogether.MasterServer.Kernel.Abstractions.Sessions;
using BeatTogether.MasterServer.Messaging.Abstractions.Messages;

namespace BeatTogether.MasterServer.Kernel.Abstractions
{
    public interface IMessageDispatcher
    {
        public Task Send<T>(
            ISession session,
            T message,
            bool requireAcknowledgement = true,
            CancellationToken cancellationToken = default)
            where T : class, IMessage;
        public void AcknowledgeMessage(uint requestId, bool handled);
    }
}
