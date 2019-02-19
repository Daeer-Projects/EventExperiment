using System;
using System.Threading.Tasks;

using EventExperimentServices.Common;
using EventExperimentServices.Extensions;
using EventExperimentServices.Generators;
using EventExperimentServices.Services;
using Serilog;

namespace EventExperimentServices
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(@"\Logs\EventExperiment-Services.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj} {NewLine}{Exception}")
                .CreateLogger();

            Log.Logger.Information($"Welcome to the messaging service using events.");

            var messageGenerator = new MessageGenerator(Log.Logger);
            var messageService = new MessageService(Log.Logger);
            var messageTypeService = new MessageTypeSwitchService(Log.Logger);
            var eventContainer = new EventPubSubContainer(messageService, messageTypeService)
                .SetUpEventConnections();

            Parallel.For(1, 100, (x) =>
            {
                Log.Logger.Information($"Item: {x}.");
                var message = messageGenerator.GenerateNewMessage();
                messageService.SendMessageEvent(message);
                var messageDetail =
                    $"Type: {message.MessageTypes.ToString("G")}, Messages: {string.Join(",", message.MessageList)}.";
                Log.Logger.Information(Constants.LogMessageTemplate, message.MessageId, "Program", "Main", messageDetail);
            });

            Console.WriteLine("Press any key to continue.");
            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}