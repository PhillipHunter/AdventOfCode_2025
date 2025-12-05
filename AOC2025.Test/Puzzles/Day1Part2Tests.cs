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
    public class Day1Part2Tests
    {
        [Fact]
        public void NameField_WhenCalled_ReturnsProperFormat()
        {
            CommonTests.ValidateNameField<Day1Part2>();
        }

        [Fact]
        public void GetOutput_WhenCalledWithExample_ReturnsExampleAnswer()
        {
            CommonTests.ValidateOutput<Day1Part2>(true);
        }

        [Fact]
        public void GetOutput_WhenCalledWithoutExample_ReturnsAnswer()
        {
            CommonTests.ValidateOutput<Day1Part2>(false);
        }

        [Theory]
        [InlineData(50, -68, 82, 1)]
        [InlineData(52, 48, 0, 1)]
        [InlineData(20, -20, 0, 1)]
        [InlineData(20, 80, 0, 1)]
        [InlineData(88, 479, 67, 5)]
        [InlineData(57, -238, -81, 2)]
        [InlineData(0, -5, 95, 0)]
        public void CalculateNewPosition_WhenCalled_ReturnsProperResult(
            int currentPos,
            int movement,
            int expected,
            int? expectedClicksAtZero
        )
        {
            // Act
            var result = Day1Part2.CalculateNewPosition(
                currentPos,
                movement,
                out var resultClicksAtZero
            );

            // Assert
            Assert.Equal(expected, result);

            if (expectedClicksAtZero != null)
                Assert.Equal(expectedClicksAtZero, resultClicksAtZero);
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
            var result = Day1Part2.RotationTextToMovement(rotationText);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
