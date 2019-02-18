using System;
using System.Linq;
using System.Threading.Tasks;
using EventExperimentServices.Generators;
using Serilog;

namespace EventExperimentServices
{
    class Program
    {
        static void Main(string[] args)
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

            Parallel.For(1, 100, (x) =>
            {
                Log.Logger.Information($"Item: {x}.");
                var message = messageGenerator.GenerateNewMessage();
                Log.Logger.Information(
                    $"Message Generated: Id: {message.MessageId}, Type: {message.MessageTypes.ToString("G")}, Messages: {string.Join(",", message.MessageList)}.");
            });


            Console.WriteLine("Press any key to continue.");
            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}
