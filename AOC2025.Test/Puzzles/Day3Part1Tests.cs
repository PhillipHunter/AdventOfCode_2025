using AOC2025.Puzzles;

namespace AOC2025.Tests.Puzzles
{
    public class Day3Part1Tests
    {
        [Fact]
        public void NameField_WhenCalled_ReturnsProperFormat()
        {
            CommonTests.ValidateNameField<Day3Part1>();
        }

        [Fact]
        public void GetOutput_WhenCalledWithExample_ReturnsExampleAnswer()
        {
            CommonTests.ValidateOutput<Day3Part1>(true);
        }

        [Fact]
        public void GetOutput_WhenCalledWithoutExample_ReturnsAnswer()
        {
            CommonTests.ValidateOutput<Day3Part1>(false);
        }

        [Theory]
        [InlineData(new byte[] { 2 }, new byte[] { 2 })]
        [InlineData(new byte[] { 2, 1, 3 }, new byte[] { 21, 23, 13 })]
        public void GetBatteryCombinations_WhenCalled_ReturnsProperResult(
            byte[] bank,
            byte[] expected
        )
        {
            // Act
            var result = Day3Part1.GetBatteryCombinations(bank.ToList());

            // Assert
            Assert.Equivalent(expected, result, true);
        }
    }
}
