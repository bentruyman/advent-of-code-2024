using AdventOfCode2024.Lib;

namespace AdventOfCode2024;

public class Day01 : IDay
{
    public string PartOne(string input)
    {
        var numbers = input.Trim().Split('\n')
            .Select(line => line.Split("   "))
            .Select(parts => (Left: int.Parse(parts[0]), Right: int.Parse(parts[1])))
            .ToList();

        var left = numbers.Select(n => n.Left).OrderBy(n => n);
        var right = numbers.Select(n => n.Right).OrderBy(n => n);

        var sum = left.Zip(right, (l, r) => Math.Abs(l - r)).Sum();

        return sum.ToString();
    }

    public string PartTwo(string input)
    {
        var numbers = input.Trim().Split('\n')
            .Select(line => line.Split("   "))
            .Select(parts => (Left: int.Parse(parts[0]), Right: int.Parse(parts[1])))
            .ToList();

        var left = numbers.Select(n => n.Left);
        var rightCounts = numbers.Select(n => n.Right)
            .GroupBy(n => n)
            .ToDictionary(g => g.Key, g => g.Count());

        var sum = left.Sum(leftNumber =>
            leftNumber * (rightCounts.TryGetValue(leftNumber, out var count) ? count : 0));

        return sum.ToString();
    }
}
