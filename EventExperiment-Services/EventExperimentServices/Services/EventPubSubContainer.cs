using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventExperimentServices.Services
{
    public class EventPubSubContainer
    {
        public MessageService MessageService { get; set; }
        public MessageTypeSwitchService MessageTypeSwitchService { get; set; }

        public EventPubSubContainer(MessageService messageService, MessageTypeSwitchService typeSwitchService)
        {
            MessageService = messageService;
            MessageTypeSwitchService = typeSwitchService;
        }
    }
}
