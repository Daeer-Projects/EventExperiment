using System;
using System.Collections.Generic;
using System.Text;
using EventExperimentServices.Common;

namespace EventExperimentServices.Types
{
    /// <summary>
    /// This is the messages that will be generated.
    /// </summary>
    public class Message
    {
        public Guid MessageId { get; }

        public Enums.MessageTypes MessageTypes { get; }

        public IList<string> MessageList { get; }

        public Message(Guid id, Enums.MessageTypes type, IList<string> messages)
        {
            MessageId = id;
            MessageTypes = type;
            MessageList = messages;
        }

        public Message SetMessageId(Guid id)
        {
            return new Message(id, MessageTypes, MessageList);
        }

        public Message SetMessageType(Enums.MessageTypes type)
        {
            return new Message(MessageId, type, MessageList);
        }

        public Message SetMessageList(IList<string> messages)
        {
            return new Message(MessageId, MessageTypes, messages);
        }
    }
}
