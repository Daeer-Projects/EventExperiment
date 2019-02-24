using System;

using Easy.MessageHub;
using EventExperiment_EasyHub.Types;
using EventExperimentServices.Common;
using Serilog;

namespace EventExperiment_EasyHub.Services
{
    public class MovementService
    {
        private readonly ILogger _logger;
        private readonly IMessageHub _messageHub;

        private Guid _token;

        public MovementService(ILogger log, IMessageHub hub)
        {
            _logger = log;
            _messageHub = hub;

            _token = _messageHub.Subscribe<MovementMessage>(OnMovementReceivedEvent);
        }

        private void OnMovementReceivedEvent(MovementMessage movement)
        {
            var message =
                $"Message received.  Figuring out where to move to... Movement: {movement.Message}.";

            _logger.Information(Constants.LogMessageTemplate, movement.MessageId, GetType().Name,
                "OnMovementReceivedEvent", message);

        }
    }
}