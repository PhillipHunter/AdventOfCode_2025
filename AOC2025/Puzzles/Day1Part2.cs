using System.Configuration;
using System.Diagnostics;

namespace AOC2025.Puzzles
{
    public class Day1Part2 : IAdventPuzzle
    {
        public string Name => "Day 1: Secret Entrance Part 2";
        public string? Solution => "-1337";
        public string? ExampleSolution => "6";
        public bool ExampleRun { get; set; } = false;

        private string _filename = "Day1.txt";

        public const int StartingPosition = 50;
        public const int TotalPositions = 100;

        public PuzzleOutput GetOutput()
        {
            var stopwatch = Stopwatch.StartNew();

            #region Puzzle

            if (ExampleRun)
            {
                _filename =
                    $"{Path.GetFileNameWithoutExtension(_filename)}Ex{Path.GetExtension(_filename)}";
            }

            var path = ConfigurationManager.AppSettings["PuzzleInputDirectory"];

            var currPuzzleFileLines = File.ReadAllLines(
                Path.Combine(
                    ConfigurationManager.AppSettings["PuzzleInputDirectory"]
                        ?? "../../../../Inputs/",
                    _filename
                )
            );

            var currentPosition = StartingPosition;
            var result = 0;

            foreach (var currPuzzleFileLine in currPuzzleFileLines)
            {
                var currentMovement = RotationTextToMovement(currPuzzleFileLine);
                currentPosition = CalculateNewPosition(
                    currentPosition,
                    currentMovement,
                    out var clicksAtZero
                );

                //if (currentPosition == 0)
                //{
                //    result++;
                //}

                result += clicksAtZero;

                AOC.Log(
                    $"{currPuzzleFileLine} land at {currentPosition} with {clicksAtZero} clicks at zero. Total zeros: {result}"
                );
            }

            #endregion Puzzle

            stopwatch.Stop();

            var puzzleOutput = new PuzzleOutput
            {
                Result = result.ToString(),
                CompletionTime = stopwatch.ElapsedMilliseconds,
            };

            return puzzleOutput;
        }

        public static int RotationTextToMovement(string rotationText)
        {
            var intPart = int.Parse(rotationText.Substring(1));
            var sign = (rotationText.FirstOrDefault() == 'L') ? -1 : 1;

            return intPart * sign;
        }

        public static int CalculateNewPosition(int currentPos, int movement, out int clicksAtZero)
        {
            var sum = (currentPos + movement);
            var landPos = (TotalPositions + sum) % TotalPositions;

            if (sum == 0)
            {
                clicksAtZero = 1;
            }
            else
            {
                clicksAtZero = Math.Abs((sum - (sum % 100)) / TotalPositions);
            }

            if (currentPos != 0 && sum < 0)
            {
                clicksAtZero++;
            }

            return landPos;
        }
    }
}
