using System.Configuration;
using System.Diagnostics;

namespace AOC2025.Puzzles
{
    public class Day1Part1 : IAdventPuzzle
    {
        public string Name => "Day 1: Scaffolding Part 1";
        public string? Solution => "1337";
        public string? ExampleSolution => "13370";
        public bool ExampleRun { get; set; } = false;

        private string _filename = "Day1.txt";

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

            var ans = currPuzzleFileLines.FirstOrDefault();

            #endregion Puzzle

            stopwatch.Stop();

            var puzzleOutput = new PuzzleOutput
            {
                Result = ans.ToString(),
                CompletionTime = stopwatch.ElapsedMilliseconds,
            };

            return puzzleOutput;
        }
    }
}
