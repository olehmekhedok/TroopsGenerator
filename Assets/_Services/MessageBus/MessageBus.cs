using System;
using System.Collections.Generic;

namespace Services.MessageBus
{
    //TODO it's draft implementation 
    public class MessageBus : IMessageBus
    {
        private readonly Dictionary<Type, object> _callbacks = new Dictionary<Type, object>();

        public void AddListener<TMessage>(Action<TMessage> callback) where TMessage : struct, IMessage
        {
            var msgType = typeof(TMessage);

            Action<TMessage> action;
            if (_callbacks.TryGetValue(msgType, out var actionObject))
            {
                action = (Action<TMessage>)actionObject;
            }
            else
            {
                action = delegate { };
            }

            action += callback;
            _callbacks[msgType] = action;
        }

        public void RemoveListener<TMessage>(Action<TMessage> callback) where TMessage : struct, IMessage
        {
            var msgType = typeof(TMessage);

            if (_callbacks.TryGetValue(msgType, out var actionObject))
            {
                var action = (Action<TMessage>)actionObject;
                action -= callback;
                _callbacks[msgType] = action;
            }
        }

        public void Dispatch<TMessage>(TMessage message) where TMessage : struct, IMessage
        {
            var msgType = typeof(TMessage);

            if (_callbacks.TryGetValue(msgType, out var actionObject))
            {
                var action = (Action<TMessage>)actionObject;
                action(message);
            }
        }
    }
}
