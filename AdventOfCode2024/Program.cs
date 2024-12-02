namespace AdventOfCode2024;

internal class Program
{
    private static void Main(string[] args)
    {
        var day01 = new Day01();
        var day01Input = File.ReadAllText("Day01/input.txt");

        var day1p1 = day01.PartOne(day01Input);
        var day1p2 = day01.PartTwo(day01Input);

        Console.WriteLine("=== Day 1 ===");
        Console.WriteLine(day1p1);
        Console.WriteLine(day1p2);

        var day02 = new Day02();
        var day02Input = File.ReadAllText("Day02/input.txt");

        var day2p1 = day02.PartOne(day02Input);
        var day2p2 = day02.PartTwo(day02Input);

        Console.WriteLine("=== Day 2 ===");
        Console.WriteLine(day2p1);
        Console.WriteLine(day2p2);
    }
}
