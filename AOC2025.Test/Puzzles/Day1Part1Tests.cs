using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AOC2025.Puzzles;

namespace AOC2025.Tests.Puzzles
{
    public class Day1Part1Tests
    {
        [Fact]
        public void NameField_WhenCalled_ReturnsProperFormat()
        {
            CommonTests.ValidateNameField<Day1Part1>();
        }

        [Fact]
        public void GetOutput_WhenCalledWithExample_ReturnsExampleAnswer()
        {
            CommonTests.ValidateOutput<Day1Part1>(true);
        }

        [Fact]
        public void GetOutput_WhenCalledWithoutExample_ReturnsAnswer()
        {
            CommonTests.ValidateOutput<Day1Part1>(false);
        }

        [Theory]
        [InlineData(50, -68, 82)]
        [InlineData(52, 48, 0)]
        [InlineData(20, -20, 0)]
        [InlineData(20, 80, 0)]
        [InlineData(88, 479, 67)]
        [InlineData(57, -238, -81)]
        public void CalculateNewPosition_WhenCalled_ReturnsProperResult(
            int currentPos,
            int movement,
            int expected
        )
        {
            // Act
            var result = Day1Part1.CalculateNewPosition(currentPos, movement);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("R20", 20)]
        [InlineData("L35", -35)]
        public void RotationTextToMovement_WhenCalled_ReturnsProperResult(
            string rotationText,
            int expected
        )
        {
            // Act
            var result = Day1Part1.RotationTextToMovement(rotationText);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
