using System;

namespace EventExperiment_EasyHub.Types
{
    public class MovementMessage
    {
        public Guid MessageId { get; }

        public string Message { get; }

        public MovementMessage(Guid id, string message)
        {
            MessageId = id;
            Message = message;
        }
    }
}