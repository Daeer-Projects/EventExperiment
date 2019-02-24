using System;

using Easy.MessageHub;
using EventExperiment_EasyHub.Types;
using EventExperimentServices.Common;
using Serilog;

namespace EventExperiment_EasyHub.Services
{
    public class ActionService
    {
        private readonly ILogger _logger;
        private readonly IMessageHub _messageHub;

        private Guid _token;

        public ActionService(ILogger log, IMessageHub hub)
        {
            _logger = log;
            _messageHub = hub;

            _token = _messageHub.Subscribe<ActionMessage>(OnActionReceivedEvent);
        }

        private void OnActionReceivedEvent(ActionMessage action)
        {
            var message =
                $"Message received.  Figuring out what we are doing... Action: {action.Message}. Object: {action.ActionOnObject}. Monster: {action.ActionOnMonster}.";
            _logger.Information(Constants.LogMessageTemplate, action.MessageId, GetType().Name,
                "OnActionReceivedEvent", message);
        }
    }
}