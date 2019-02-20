using System;
using System.Threading.Tasks;
using Easy.MessageHub;
using EventExperimentServices.Common;
using EventExperiment_EasyHub.Generators;
using EventExperiment_EasyHub.Services;
using Serilog;

namespace EventExperiment_EasyHub
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(@"\Logs\EventExperiment-EasyHub.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj} {NewLine}{Exception}")
                .CreateLogger();

            Log.Logger.Information($"Welcome to the messaging service using the Easy Message Hub.");

            var messageGenerator = new MessageGenerator(Log.Logger);
            var hub = MessageHub.Instance;
            var messageService = new MessageService(Log.Logger, hub);
            var messageType = new MessageTypeSwitchService(Log.Logger, hub);

            Parallel.For(1, 100, (x) =>
            {
                Log.Logger.Information($"Item: {x}.");
                var message = messageGenerator.GenerateNewMessage();
                messageService.SendMessage(message);
                var messageDetail =
                    $"Type: {message.MessageTypes:G}, Messages: {string.Join(",", message.MessageList)}.";
                Log.Logger.Information(Constants.LogMessageTemplate, message.MessageId, "Program", "Main", messageDetail);
            });

            hub.ClearSubscriptions();
            Console.WriteLine("Press any key to continue.");
            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}
