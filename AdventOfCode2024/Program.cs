using System.Diagnostics;
using System.Reflection;
using AdventOfCode2024.Lib;

namespace AdventOfCode2024;

internal static class Program
{
    private static void Main(string[] args)
    {
        var dayNumbersToRun = args.Length > 0
            ? args.Select(int.Parse).ToHashSet()
            : null;

        var executablePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Debug.Assert(executablePath != null, nameof(executablePath) + " != null");
        var projectRoot = Path.Combine(executablePath, "..", "..", "..");

        var dayTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IDay).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
            .OrderBy(t => t.Name);

        foreach (var dayType in dayTypes)
        {
            var dayInstance = (IDay)Activator.CreateInstance(dayType)!;

            if (dayInstance == null) throw new Exception($"Day {dayType.Name} is not a valid day.");

            var dayNumberString = new string(dayType.Name.SkipWhile(c => !char.IsDigit(c)).ToArray());
            var dayNumber = int.Parse(dayNumberString);

            if (dayNumbersToRun != null && !dayNumbersToRun.Contains(dayNumber))
                continue;

            var inputPath = Path.Combine(projectRoot, $"Day{dayNumberString}", "input.txt");
            var input = File.ReadAllText(inputPath);

            var partOneResult = dayInstance.PartOne(input);
            var partTwoResult = dayInstance.PartTwo(input);

            Console.WriteLine($"> Day {dayNumber} <");
            Console.WriteLine($"Part 1: {partOneResult}");
            Console.WriteLine($"Part 2: {partTwoResult}");
        }
    }
}
