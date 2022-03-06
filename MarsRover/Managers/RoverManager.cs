using MarsRover.Business;
using MarsRover.Enums;
using MarsRover.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Managers
{
    public class RoverManager : IRoverManager
    {
        private readonly IRoverService _roverService;
        private readonly ILogger<RoverManager> _logger;
        public RoverManager(ILoggerFactory loggerFactory, IRoverService roverService)
        {
            _logger = loggerFactory.CreateLogger<RoverManager>();
            _roverService = roverService;
        }
        public void Execute(string command)
        {
            command.ToList().ForEach(cmd =>
            {
                switch (cmd)
                {
                    case (char)Command.M:
                        {
                            if (!Move())
                            {
                                throw new OutOfBorderException();
                            }
                            break;
                        }
                    case (char)Command.L:
                        TurnLeft();
                        break;
                    case (char)Command.R:
                        TurnRight();
                        break;
                    default:
                        throw new InvalidCommandException();
                }
            });
            _logger.LogInformation($"Given commands = '{command}'");
        }
        public string GetStatus()
        {
            return $"{_roverService.GetCurrentCoordinate().X} {_roverService.GetCurrentCoordinate().Y} {_roverService.GetCurrentDirection()}";
        }
        private void TurnLeft()
        {
            _roverService.SetDirection(_roverService.GetCurrentDirection() - 1 < Direction.N
                ? Direction.W
                : _roverService.GetCurrentDirection() - 1);
        }
        private void TurnRight()
        {
            _roverService.SetDirection(_roverService.GetCurrentDirection() + 1 > Direction.W
                ? Direction.N
                : _roverService.GetCurrentDirection() + 1);
        }
        private bool Move()
        {
            if (!_roverService.IsOutControl())
                return false;

            switch (_roverService.GetCurrentDirection())
            {
                case Direction.N:
                    _roverService.GetCurrentCoordinate().Y += 1;
                    break;
                case Direction.E:
                    _roverService.GetCurrentCoordinate().X += 1;
                    break;
                case Direction.S:
                    _roverService.GetCurrentCoordinate().Y -= 1;
                    break;
                case Direction.W:
                    _roverService.GetCurrentCoordinate().X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return true;
        }
    }
}
