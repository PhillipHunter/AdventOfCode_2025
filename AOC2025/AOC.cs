using System.Diagnostics;
using AOC2025.Puzzles;

namespace AOC2025
{
    public class AOC
    {
        private static readonly List<IAdventPuzzle> AdventPuzzles = [];

        public static IAdventPuzzle[] GetAdventPuzzles()
        {
            // Add Puzzles Here
            #region Puzzle List
            AdventPuzzles.Add(new Day1Part1());
            AdventPuzzles.Add(new Day2Part1());
            AdventPuzzles.Add(new Day2Part2());
            #endregion Puzzle List

            return AdventPuzzles.ToArray();
        }

        public static void Log(string message)
        {
#if DEBUG
            Debug.WriteLine(message);
#endif
        }
    }
}
