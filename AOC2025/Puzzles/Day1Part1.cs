using System.Configuration;
using System.Diagnostics;

namespace AOC2025.Puzzles
{
    public class Day1Part1 : IAdventPuzzle
    {
        public string Name => "Day 1: Secret Entrance Part 1";
        public string? Solution => "1092";
        public string? ExampleSolution => "3";
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
                currentPosition = CalculateNewPosition(currentPosition, currentMovement);

                if (currentPosition == 0)
                {
                    result++;
                }
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

        public static int CalculateNewPosition(int currentPos, int movement)
        {
            return (TotalPositions + (currentPos + movement)) % TotalPositions;
        }
    }
}
