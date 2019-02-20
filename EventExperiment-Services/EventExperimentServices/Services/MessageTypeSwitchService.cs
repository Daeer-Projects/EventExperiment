using System;
using EventExperimentServices.Common;
using EventExperimentServices.EventArguments;

using Serilog;

namespace EventExperimentServices.Services
{
    public class MessageTypeSwitchService
    {
        private readonly ILogger _logger;

        public event EventHandler<MovementTypeEventArgs> MovementEventHandler = delegate { };
        public event EventHandler<ActionTypeEventArgs> ActionEventHandler = delegate { };
        public event EventHandler<ObjectTypeEventArgs> ObjectEventHandler = delegate { };
        public event EventHandler<MonsterTypeEventArgs> MonsterEventHandler = delegate { };

        public MessageTypeSwitchService(ILogger log)
        {
            _logger = log;
        }

        /// <exception cref="T:System.Exception">A delegate callback throws an exception.</exception>
        public void OnMessageReceivedEvent(object sender, MessageSentReceivedArgs args)
        {
            _logger.Information(Constants.LogMessageTemplate, args.SentMessage.MessageId, GetType().Name,
                "OnMessageReceivedEvent", "Message received.  Sending on.");

            switch (args.SentMessage.MessageTypes)
            {
                case Enums.MessageTypes.Movement:
                    {
                        _logger.Information(Constants.LogMessageTemplate, args.SentMessage.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Movement type detected. Sending on.");
                        //MovementEventHandler?.Invoke(this,
                        //    new MovementTypeEventArgs(
                        //        new Exception("Movement Handler: Error."),
                        //        false,
                        //        "Movement Sent Event.",
                        //        args.SentMessage.MessageList));
                        MovementEventHandler(this,
                            new MovementTypeEventArgs(
                                new Exception("Movement Handler: Error."),
                                false,
                                "Movement Sent Event.",
                                args.SentMessage.MessageList));
                        break;
                    }
                case Enums.MessageTypes.Action:
                    {
                        _logger.Information(Constants.LogMessageTemplate, args.SentMessage.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Action type detected. Sending on.");
                        ActionEventHandler(this,
                            new ActionTypeEventArgs(
                                new Exception("Action Handler: Error."),
                                false,
                                "Action Sent Event.",
                                args.SentMessage.MessageList));
                        break;
                    }
                case Enums.MessageTypes.Object:
                    {
                        _logger.Information(Constants.LogMessageTemplate, args.SentMessage.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Object type detected. Sending on.");
                        ObjectEventHandler(this,
                            new ObjectTypeEventArgs(
                                new Exception("Object Handler: Error."),
                                false,
                                "Object Sent Event.",
                                args.SentMessage.MessageList));
                        break;
                    }
                case Enums.MessageTypes.Monster:
                    {
                        _logger.Information(Constants.LogMessageTemplate, args.SentMessage.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Monster type detected.  Sending on.");
                        MonsterEventHandler(this,
                            new MonsterTypeEventArgs(
                                new Exception("Monster Handler: Error."),
                                false,
                                "Monster Sent Event.",
                                args.SentMessage.MessageList));
                        break;
                    }
                default:
                    {
                        _logger.Error(Constants.LogMessageTemplate, args.SentMessage.MessageId, GetType().Name,
                            "OnMessageReceivedEvent", "Unknown type detected.");
                        throw new ArgumentOutOfRangeException("Unknown type detected.");
                    }
            }
        }
    }
}