using System.Configuration;
using System.Diagnostics;

namespace AOC2025.Puzzles
{
    public class Day3Part1 : IAdventPuzzle
    {
        public string Name => "Day 3: Lobby Part 1";
        public string? Solution => "17311";
        public string? ExampleSolution => "357";
        public bool ExampleRun { get; set; } = false;

        private string _filename = "Day3.txt";

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

            var maxes = new List<int>();
            foreach (var currPuzzleFileLine in currPuzzleFileLines)
            {
                var currBank = new List<byte>();
                foreach (var currPuzzleFileLineChar in currPuzzleFileLine)
                {
                    var currJoltage = byte.Parse(currPuzzleFileLineChar.ToString());

                    currBank.Add(currJoltage);
                }

                var combinations = GetBatteryCombinations(currBank);
                var maxCombination = combinations.Max();
                maxes.Add(maxCombination);

                AOC.Log($"For {currPuzzleFileLine}, max is: {maxCombination}");
            }

            var result = maxes.Sum();

            #endregion Puzzle

            stopwatch.Stop();

            var puzzleOutput = new PuzzleOutput
            {
                Result = result.ToString(),
                CompletionTime = stopwatch.ElapsedMilliseconds,
            };

            return puzzleOutput;
        }

        public static List<byte> GetBatteryCombinations(List<byte> bank)
        {
            var batteryCombinations = new List<byte>();

            if (bank.Count == 1)
                return bank;

            for (
                var currentBankColumnIndex = 0;
                currentBankColumnIndex < bank.Count;
                currentBankColumnIndex++
            )
            {
                for (
                    var otherBankColumnIndex = currentBankColumnIndex + 1;
                    otherBankColumnIndex < bank.Count;
                    otherBankColumnIndex++
                )
                {
                    var joltage = byte.Parse(
                        $"{bank[currentBankColumnIndex]}{bank[otherBankColumnIndex]}"
                    );

                    batteryCombinations.Add(joltage);
                }
            }

            return batteryCombinations;
        }
    }
}
