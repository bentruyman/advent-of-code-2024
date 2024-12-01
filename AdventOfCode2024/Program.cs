using AdventOfCode2024.Day01;

namespace AdventOfCode2024;

internal class Program
{
    private static void Main(string[] args)
    {
        var day01 = new Solution();
        var day01Input = File.ReadAllText("Day01/input.txt");

        var day1p1 = day01.PartOne(day01Input);
        var day1p2 = day01.PartTwo(day01Input);

        Console.WriteLine("=== Day 1 ===");
        Console.WriteLine(day1p1);
        Console.WriteLine(day1p2);
    }
}
