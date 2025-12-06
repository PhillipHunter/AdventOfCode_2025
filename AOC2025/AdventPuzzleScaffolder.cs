using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2025
{
    public class AdventPuzzleScaffolder
    {
        private readonly string _day;
        private readonly string _name;
        private readonly string _part;
        private readonly string _solutionDirectory;
        private readonly string _puzzleInputDirectory;

        public AdventPuzzleScaffolder(string day, string name, string part)
        {
            _day = day;
            _name = name;
            _part = part;

            _solutionDirectory =
                ConfigurationManager.AppSettings["SolutionDirectory"] ?? "../../../../";

            _puzzleInputDirectory =
                ConfigurationManager.AppSettings["PuzzleInputDirectory"] ?? "../../../../Inputs";
        }

        public void ScaffoldPuzzle()
        {
            AOC.Log($"Scaffolding puzzle: Day {_day} {_name} Part {_part}");
            if (
                string.IsNullOrWhiteSpace(_day)
                || string.IsNullOrWhiteSpace(_name)
                || string.IsNullOrWhiteSpace(_part)
            )
            {
                throw new ArgumentNullException();
            }

            GeneratePuzzleCodeFile();
            GeneratePuzzleUnitTest();
            GenerateEmptyInputFiles();
            UpdatePuzzleList();

            AOC.Log("Scaffolding puzzle complete.");
        }

        private void GeneratePuzzleCodeFile()
        {
            var templateText = File.ReadAllText(
                Path.Combine(_solutionDirectory, "Templates/", "DayPuzzle.cs.template")
            );

            var puzzleCodeFileText = templateText
                .Replace("{DAY}", _day)
                .Replace("{NAME}", _name)
                .Replace("{PART}", _part);

            var puzzleCodeFileName = $"Day{_day}Part{_part}.cs";
            var puzzleCodeFileFullPath = Path.Combine(
                _solutionDirectory,
                "AOC2025/Puzzles/",
                puzzleCodeFileName
            );

            File.WriteAllText(puzzleCodeFileFullPath, puzzleCodeFileText);

            AOC.Log($"Code file generated: {puzzleCodeFileFullPath}");
        }

        private void GeneratePuzzleUnitTest()
        {
            var templateText = File.ReadAllText(
                Path.Combine(_solutionDirectory, "Templates/", "DayPuzzleTests.cs.template")
            );

            var puzzleCodeFileText = templateText
                .Replace("{DAY}", _day)
                .Replace("{NAME}", _name)
                .Replace("{PART}", _part);

            var puzzleCodeFileName = $"Day{_day}Part{_part}Tests.cs";
            var puzzleCodeFileFullPath = Path.Combine(
                _solutionDirectory,
                "AOC2025.Test/Puzzles/",
                puzzleCodeFileName
            );

            File.WriteAllText(puzzleCodeFileFullPath, puzzleCodeFileText);

            AOC.Log($"Unit Test file generated: {puzzleCodeFileFullPath}");
        }

        private void GenerateEmptyInputFiles()
        {
            File.WriteAllText(Path.Combine(_puzzleInputDirectory, $"Day{_day}.txt"), string.Empty);

            File.WriteAllText(
                Path.Combine(_puzzleInputDirectory, $"Day{_day}Ex.txt"),
                string.Empty
            );

            AOC.Log($"Input files generated at {_puzzleInputDirectory}.");
        }

        private void UpdatePuzzleList()
        {
            var aocClassFileFullPath = Path.Combine(_solutionDirectory, "AOC2025/", "AOC.cs");

            var aocClassLines = File.ReadAllLines(aocClassFileFullPath);

            var preRegionLines = new List<string>();
            var inRegionLines = new List<string>();
            var postRegionLines = new List<string>();

            var parseState = AOCClassParseState.PreRegion;

            foreach (var currAocClassLine in aocClassLines)
            {
                if (currAocClassLine.Contains("#endregion Puzzle List"))
                    parseState = AOCClassParseState.PostRegion;

                switch (parseState)
                {
                    case AOCClassParseState.PreRegion:
                        preRegionLines.Add(currAocClassLine);
                        break;
                    case AOCClassParseState.InRegion:
                        inRegionLines.Add(currAocClassLine);
                        break;
                    case AOCClassParseState.PostRegion:
                        postRegionLines.Add(currAocClassLine);
                        break;
                }

                if (currAocClassLine.Contains("#region Puzzle List"))
                    parseState = AOCClassParseState.InRegion;
            }

            inRegionLines.Add($"            AdventPuzzles.Add(new Day{_day}Part{_part}());");
            inRegionLines.Sort();

            var outputBuilder = new StringBuilder();

            AppendLines(outputBuilder, preRegionLines);
            AppendLines(outputBuilder, inRegionLines);
            AppendLines(outputBuilder, postRegionLines);

            File.WriteAllText(aocClassFileFullPath, outputBuilder.ToString());

            AOC.Log($"Puzzle list updated at: {aocClassFileFullPath}");
        }

        private static void AppendLines(
            StringBuilder stringBuilder,
            IEnumerable<string> values,
            string newLine = "\r\n"
        )
        {
            foreach (var currValue in values)
            {
                stringBuilder.Append($"{currValue}{newLine}");
            }
        }

        private enum AOCClassParseState
        {
            PreRegion,
            InRegion,
            PostRegion,
        }
    }
}
