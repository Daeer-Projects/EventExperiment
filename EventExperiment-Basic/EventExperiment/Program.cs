namespace EventExperiment
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using ExtensionMethods;
    using Publishers;
    using Serilog;
    using Subscribers;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(@"\Logs\EventExperiment.csv",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} ; [{Level:u3}] ; {Message:lj} ;{NewLine}{Exception};")
                .CreateLogger();

            var logSub = new LogSubscriber(Log.Logger);
            var customer = new CustomerSubscriber();
            var customerPub = new CustomerPublisher();
            var site = new SiteSubscriber();
            var sitePub = new SitePublisher();
            var trans = new TransactionRegistration();

            var configuration = new PipelineConfiguration(customer, customerPub, site, sitePub, trans, logSub)
                .RegisterSiteSubscriptions()
                .RegisterSitePublications()
                .RegisterCustomerSubscriptions()
                .RegisterCustomerPublications();

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            Parallel.For(1, 1000, (x) => { trans.TransactionReceivedEvent(x, Guid.NewGuid()); });

            stopWatch.Stop();
            Log.Information($"Elapsed Time (Milliseconds): {stopWatch.ElapsedMilliseconds}.");

            Console.WriteLine("Press any key to continue.");
            Log.CloseAndFlush();
            Console.ReadKey();
        }
    }
}