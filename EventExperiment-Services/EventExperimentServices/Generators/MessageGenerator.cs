using System;
using System.Collections.Generic;

using EventExperimentServices.Common;
using EventExperimentServices.Types;
using Serilog;

namespace EventExperimentServices.Generators
{
    /// <summary>
    /// This is a class that will generate new messages that the application will process using events.
    /// </summary>
    public class MessageGenerator
    {
        private readonly ILogger _logger;

        public MessageGenerator(ILogger log)
        {
            _logger = log;
        }

        public Message GenerateNewMessage()
        {
            // Need a message Id.  A new Guid.
            var newMessageId = Guid.NewGuid();

            // Need to get a message type.
            var newMessageType = GenerateRandomType();

            // Need to get a list of actions / movement / re-actions based on the type.
            var messageList = GenerateMessages(newMessageType);

            var newMessage = new Message(newMessageId, newMessageType, messageList);

            return newMessage;
        }

        private Enums.MessageTypes GenerateRandomType()
        {
            var random = new Random();
            var type = (Enums.MessageTypes)random.Next(0, 2);
            return type;
        }

        private IList<string> GenerateMessages(Enums.MessageTypes currentType)
        {
            var messages = new List<string>();

            switch (currentType)
            {
                case Enums.MessageTypes.Movement:
                    {
                        var random = new Random();
                        var messageSelection = random.Next(0, Constants.MovementItems.Count - 1);

                        messages.Add(Constants.MovementItems.AsReadOnly()[messageSelection]);
                        break;
                    }
                case Enums.MessageTypes.Action:
                    {
                        var random = new Random();
                        var messageSelection = random.Next(0, Constants.ActionItems.Count - 1);

                        messages.Add(Constants.ActionItems.AsReadOnly()[messageSelection]);
                        break;
                    }
                case Enums.MessageTypes.ReAction:
                    {
                        var random = new Random();
                        var messageSelection = random.Next(0, Constants.ReActionItems.Count - 1);

                        messages.Add(Constants.ReActionItems.AsReadOnly()[messageSelection]);
                        break;
                    }
                default:
                    {
                        _logger.Error($"{GetType().Name} (GenerateMessages) - Unable to identify the message type.");
                        break;
                    }
            }

            return messages;
        }
    }
}