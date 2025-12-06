using System.Buffers;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;

namespace AOC2025.Puzzles
{
    public class Day6Part1 : IAdventPuzzle
    {
        public string Name => "Day 6: Trash Compactor Part 1";
        public string? Solution => "4449991244405";
        public string? ExampleSolution => "4277556";
        public bool ExampleRun { get; set; } = false;

        private string _filename = "Day6.txt";

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

            var parsedPuzzleInput = ParsePuzzleInput(currPuzzleFileLines);

            var columnCount = parsedPuzzleInput.Operations.Count;
            var result = 0L;
            for (var currColumnIndex = 0; currColumnIndex < columnCount; currColumnIndex++)
            {
                var currOperation = parsedPuzzleInput.Operations[currColumnIndex];
                var currTotal = 0L;

                foreach (var currNumberList in parsedPuzzleInput.Numbers)
                {
                    switch (currOperation)
                    {
                        case Operation.Addition:
                            currTotal += currNumberList[currColumnIndex];
                            break;
                        case Operation.Multiplication:
                            if (currTotal == 0) // Account for starting *0 edge case
                                currTotal = currNumberList[currColumnIndex];
                            else
                                currTotal *= currNumberList[currColumnIndex];
                            break;
                    }
                }

                AOC.Log($"Done with line {currColumnIndex}, adding {currTotal} to result.");

                result += currTotal;
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

        private ParseSet ParsePuzzleInput(string[] currPuzzleFileLines)
        {
            var operations = new List<Operation>();
            var numbers = new List<List<int>>();
            for (var i = 0; i < currPuzzleFileLines.Length; i++)
            {
                var currPuzzleFileLine = currPuzzleFileLines[i];
                var currPuzzleFileLineSplit = currPuzzleFileLine.Split(
                    ' ',
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
                );

                if (currPuzzleFileLine.Contains('+') || currPuzzleFileLine.Contains('*'))
                {
                    foreach (var currOperationText in currPuzzleFileLineSplit)
                    {
                        switch (currOperationText)
                        {
                            case "+":
                                operations.Add(Operation.Addition);
                                break;
                            case "*":
                                operations.Add(Operation.Multiplication);
                                break;
                        }
                    }
                }
                else
                {
                    var lineList = new List<int>();
                    foreach (var currNumberText in currPuzzleFileLineSplit)
                    {
                        lineList.Add(int.Parse(currNumberText));
                    }

                    numbers.Add(lineList);
                }
            }

            return new ParseSet() { Operations = operations, Numbers = numbers };
        }

        private enum Operation
        {
            Addition,
            Multiplication,
        }

        private class ParseSet
        {
            public List<Operation> Operations { get; set; }
            public List<List<int>> Numbers { get; set; }
        }
    }
}
