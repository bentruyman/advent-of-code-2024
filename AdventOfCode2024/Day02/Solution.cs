using AdventOfCode2024.Lib;

namespace AdventOfCode2024;

public class Day02 : IDay
{
    private const int MaxDistance = 3;

    public string PartOne(string input)
    {
        return ParseReport(input).Count(report => IsSafe(report)).ToString();
    }

    public string PartTwo(string input)
    {
        return ParseReport(input)
            .Count(report => IsSafe(report) || CanBeMadeSafe(report))
            .ToString();
    }

    private static List<List<int>> ParseReport(string input)
    {
        return input
            .Trim()
            .Split("\n")
            .Select(line => line.Split(" ").Select(int.Parse).ToList())
            .ToList();
    }

    private static bool IsSafe(List<int> levels, int skipIndex = -1)
    {
        var count = levels.Count - (skipIndex >= 0 ? 1 : 0);
        if (count <= 1)
            return true;

        var isIncreasing = true;
        var isDecreasing = true;
        var prevValue = 0;
        var hasPrevValue = false;

        for (var i = 0; i < levels.Count; i++)
        {
            if (i == skipIndex)
                continue;

            if (!hasPrevValue)
            {
                prevValue = levels[i];
                hasPrevValue = true;
                continue;
            }

            var currentValue = levels[i];
            var diff = currentValue - prevValue;

            if (Math.Abs(diff) < 1 || Math.Abs(diff) > MaxDistance)
                return false;

            if (diff > 0)
                isDecreasing = false;
            else if (diff < 0)
                isIncreasing = false;
            else
                return false;

            if (!isIncreasing && !isDecreasing)
                return false;

            prevValue = currentValue;
        }

        return true;
    }

    private static bool CanBeMadeSafe(List<int> levels)
    {
        return levels.Where((t, i) => IsSafe(levels, i)).Any();
    }
}
