using System;
using System.ComponentModel;

using EventExperimentServices.Types;

namespace EventExperimentServices.EventArguments
{
    public class MessageSentReceivedArgs : AsyncCompletedEventArgs
    {
        public MessageSentReceivedArgs(Exception error, bool cancelled, object userState, Message message)
            : base(error, cancelled, userState)
        {
            SentMessage = message;
        }

        public Message SentMessage { get; }
    }
}