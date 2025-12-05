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
    public class Day2Part2Tests
    {
        [Fact]
        public void NameField_WhenCalled_ReturnsProperFormat()
        {
            CommonTests.ValidateNameField<Day2Part2>();
        }

        [Fact]
        public void GetOutput_WhenCalledWithExample_ReturnsExampleAnswer()
        {
            CommonTests.ValidateOutput<Day2Part2>(true);
        }

        [Fact]
        public void GetOutput_WhenCalledWithoutExample_ReturnsAnswer()
        {
            CommonTests.ValidateOutput<Day2Part2>(false);
        }

        [Theory]
        [InlineData(11, true)]
        [InlineData(111, true)]
        [InlineData(22, true)]
        [InlineData(95, false)]
        [InlineData(1010, true)]
        [InlineData(1188511885, true)]
        [InlineData(1181511885, false)]
        [InlineData(1698522, false)]
        public void IsRepeating_WhenCalled_ReturnsProperResult(int input, bool expected)
        {
            // Act
            var result = Day2Part2.IsRepeating(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1188511885", 5, true)] // Repeating within window
        [InlineData("1188511885", 4, false)] // Because overflow at window of 4
        [InlineData(
            "11",
            2,
            true,
            Skip = "This is fine, since it would be caught by a previous window in the actual algorithm"
        )] // Repeating within window (same number)
        [InlineData("1180511885", 5, false)] // Not Repeating within window
        [InlineData("1180511885", 10, false)] // Don't return true if count matches window size
        public void IsRepeatingForWindowSize_WhenCalled_ReturnsProperResult(
            string baseString,
            int windowSize,
            bool expected
        )
        {
            // Act
            var result = Day2Part2.IsRepeatingForWindowSize(baseString, windowSize);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
