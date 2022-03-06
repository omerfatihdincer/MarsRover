using MarsRover.Business;
using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CustomUnhandledException.UnhandledExceptionTrapper;
            var serviceProvider = BuildProvider();
            var rover = serviceProvider.GetService<IRoverService>();

            if (rover != null)
            {
                rover.SetPlateau(5,5);
                rover.SetCoordinate(1,2, Direction.N);

                var roverManager = serviceProvider.GetService<IRoverManager>();
                if (roverManager != null)
                {
                    roverManager.Execute("LMLMLMLMM");
                    Console.WriteLine($"Result = {roverManager.GetStatus()}");

                    rover.SetCoordinate(3, 3, Direction.E);
                    roverManager.Execute("MMRMMRMRRM");
                    Console.WriteLine($"Result = {roverManager.GetStatus()}");
                }
            }
            Console.ReadKey();
        }

        private static IServiceProvider BuildProvider()
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddConsole(LogLevel.Information);

            return serviceProvider;
        }
    }
}
