using Microsoft.Extensions.Logging;
using MarsRover.Entities;
using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Managers;
using System;
using Xunit;
using MarsRover.Business;

namespace StudyCase.Test
{
    public class ExceptionTests
    {
         
        [Theory]
        [InlineData(5, 5, 3, 3, Direction.E, "MMRMMRMRRMMMMMM")]
        public void ExecuteCommand_ShouldBeException_GetOutOfBorderException(int width, int height, int x, int y, Direction rotation, string command)
        {
            var rover = new RoverService();
            rover.SetPlateau(width, height);
            rover.SetCoordinate(x, y, rotation);
            var roverManager = new RoverManager(new LoggerFactory(),rover);
            Assert.Throws<OutOfBorderException>(() => roverManager.Execute(command));
        }


        [Theory]
        [InlineData(5, 5, 3, 3, Direction.E, "MMRMMRMRRMA")]
        public void ExecuteCommand_ShouldBeException_GetInvalidCommandException(int width, int height, int x, int y, Direction rotation, string command)
        {
            var rover = new RoverService();
            rover.SetPlateau(width, height);
            rover.SetCoordinate(x, y, rotation);
            var roverManager = new RoverManager(new LoggerFactory(), rover);
            Assert.Throws<InvalidCommandException>(() => roverManager.Execute(command));
        }
    }
}
