using System.Text.RegularExpressions;
using AdventOfCode2024.Lib;

namespace AdventOfCode2024;

public class Day03 : IDay
{
    public string PartOne(string input)
    {
        const string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";

        var sum = 0;

        Regex.Matches(input, pattern).ToList().ForEach(match =>
        {
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);

            sum += x * y;
        });

        return sum.ToString();
    }

    public string PartTwo(string input)
    {
        const string pattern = @"(?<mul>mul\((?<x>\d{1,3}),(?<y>\d{1,3})\))|(?<do>do\(\))|(?<dont>don't\(\))";

        var sum = 0;
        var enabled = true;

        foreach (Match match in Regex.Matches(input, pattern))
            if (match.Groups["do"].Success)
                enabled = true;
            else if (match.Groups["dont"].Success)
                enabled = false;
            else if (match.Groups["mul"].Success)
                if (enabled)
                {
                    var x = int.Parse(match.Groups["x"].Value);
                    var y = int.Parse(match.Groups["y"].Value);
                    sum += x * y;
                }

        return sum.ToString();
    }
}
