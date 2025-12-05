using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AOC2025.Puzzles
{
    public class Day2Part1 : IAdventPuzzle
    {
        public string Name => "Day 2: Gift Shop Part 1";
        public string? Solution => "44854383294";
        public string? ExampleSolution => "1227775554";
        public bool ExampleRun { get; set; } = false;

        private string _filename = "Day2.txt";

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

            var ranges = new List<Tuple<long, long>>();
            foreach (var currPuzzleFileLine in currPuzzleFileLines)
            {
                var rangeStrings = currPuzzleFileLine.Split(',');
                foreach (var currRangeString in rangeStrings)
                {
                    var rangeFacets = currRangeString.Split('-');
                    var currRange = new Tuple<long, long>(
                        long.Parse(rangeFacets[0]),
                        long.Parse(rangeFacets[1])
                    );

                    ranges.Add(currRange);
                }
            }

            var sum = 0L;

            foreach (var currRange in ranges)
            {
                AOC.Log(
                    $"{currRange.Item2} - {currRange.Item1} = {currRange.Item2 - currRange.Item1}"
                );

                for (
                    var currItemInRange = currRange.Item1;
                    currItemInRange <= currRange.Item2;
                    currItemInRange++
                )
                {
                    var valid = !IsRepeating(currItemInRange);
                    if (!valid)
                    {
                        AOC.Log($"Invalid found: {currItemInRange}");
                        sum += currItemInRange;
                    }
                }
            }

            #endregion Puzzle

            stopwatch.Stop();

            var puzzleOutput = new PuzzleOutput
            {
                Result = sum.ToString(),
                CompletionTime = stopwatch.ElapsedMilliseconds,
            };

            return puzzleOutput;
        }

        public static bool IsRepeatingForWindowSize(string baseString, int windowSize)
        {
            if (windowSize == baseString.Length)
                return false;

            var substrings = new Dictionary<string, int>();
            for (var i = 0; i < baseString.Length; i += windowSize)
            {
                var startIndex = i;

                if (i + windowSize > baseString.Length)
                {
                    return false;
                }

                var currSubstring = baseString.Substring(startIndex, windowSize);

                if (!substrings.TryAdd(currSubstring, 1))
                    substrings[currSubstring]++;

                if (substrings.Count > 1)
                {
                    return false;
                }
            }

            return substrings.FirstOrDefault().Value == 2;
        }

        public static bool IsRepeating(long input)
        {
            var baseString = input.ToString();

            for (var windowSize = 1; windowSize <= baseString.Length; windowSize++)
            {
                var repeatingForCurrentWindowSize = IsRepeatingForWindowSize(
                    baseString,
                    windowSize
                );

                if (repeatingForCurrentWindowSize)
                    return true;
            }

            return false;
        }
    }
}
