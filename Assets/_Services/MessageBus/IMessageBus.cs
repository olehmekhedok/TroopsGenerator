using System;

namespace Services.MessageBus
{
    public interface IMessageBus
    {
        void AddListener<TMessage>(Action<TMessage> callback) where TMessage : struct, IMessage;
        void RemoveListener<TMessage>(Action<TMessage> callback) where TMessage : struct, IMessage;
        void Dispatch<TMessage>(TMessage message) where TMessage : struct, IMessage;
    }
}