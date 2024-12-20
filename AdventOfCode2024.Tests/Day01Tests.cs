using AdventOfCode2024.Lib;

namespace AdventOfCode2024.Tests;

public class Day01Tests
{
    private readonly IDay _day;
    private readonly string _input;

    public Day01Tests()
    {
        _day = new Day01();
        _input = """
                 3   4
                 4   3
                 2   5
                 1   3
                 3   9
                 3   3
                 """;
    }

    [Fact]
    public void PartOneTest()
    {
        var result = _day.PartOne(_input);
        Assert.Equal("11", result);
    }

    [Fact]
    public void PartTwoTest()
    {
        var result = _day.PartTwo(_input);
        Assert.Equal("31", result);
    }
}
