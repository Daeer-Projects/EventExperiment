using System;
using System.Collections.Generic;
using System.Text;

namespace EventExperiment_EasyHub.Types
{
    public class ActionMessage
    {
        public Guid MessageId { get; }

        public string Message { get; }

        public string ActionOnObject { get; }

        public string ActionOnMonster { get; }

        public ActionMessage(Guid id, string message, string onObject, string onMonster)
        {
            MessageId = id;
            Message = message;
            ActionOnObject = onObject;
            ActionOnMonster = onMonster;
        }
    }
}
