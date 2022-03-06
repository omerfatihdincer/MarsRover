using MarsRover.Business;
using MarsRover.Exceptions;
using MarsRover.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace MarsRover
{
    public class Startup
    {
        public Startup()
        {
           
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                  .AddLogging()
                  .AddSingleton<IRoverService, RoverService>()
                  .AddSingleton<IRoverManager, RoverManager>()
                  .BuildServiceProvider();

        }
    }
}
