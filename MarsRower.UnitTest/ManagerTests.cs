using Microsoft.Extensions.Logging;
using MarsRover.Entities;
using MarsRover.Enums;
using MarsRover.Managers;
using System;
using Xunit;
using MarsRover.Business;

namespace StudyCase.Test
{
    public class ManagerTests
    {
        [Theory]
        [InlineData(5, 5, 1, 2, Direction.N, "LMLMLMLMM", "1 3 N")]
        [InlineData(5, 5, 3, 3, Direction.E, "MMRMMRMRRM", "5 1 E")]
        public void ExecuteCommand_ShouldBeEquals_GetExpectedResult(int width, int height, int x, int y, Direction rotation, string command, string expectedResult)
        {
            var rover = new RoverService();
            rover.SetPlateau(width, height);
            rover.SetCoordinate(x, y, rotation);
            var roverManager = new RoverManager(new LoggerFactory(), rover);
            roverManager.Execute(command);
            Assert.Equal(expectedResult, roverManager.GetStatus());
        }
    }
}
