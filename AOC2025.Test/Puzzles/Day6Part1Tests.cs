using AOC2025.Puzzles;

namespace AOC2025.Tests.Puzzles
{
    public class Day6Part1Tests
    {
        [Fact]
        public void NameField_WhenCalled_ReturnsProperFormat()
        {
            CommonTests.ValidateNameField<Day6Part1>();
        }

        [Fact]
        public void GetOutput_WhenCalledWithExample_ReturnsExampleAnswer()
        {
            CommonTests.ValidateOutput<Day6Part1>(true);
        }

        [Fact]
        public void GetOutput_WhenCalledWithoutExample_ReturnsAnswer()
        {
            CommonTests.ValidateOutput<Day6Part1>(false);
        }
    }
}
