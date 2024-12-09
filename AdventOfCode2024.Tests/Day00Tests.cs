using AdventOfCode2024.Lib;

namespace AdventOfCode2024.Tests;

public class Day00Tests
{
    private readonly IDay _day;
    private readonly string _input;

    public Day00Tests()
    {
        _day = new Day00();
        _input = """
                 123
                 """;
    }

    [Fact]
    public void PartOneTest()
    {
        var result = _day.PartOne(_input);
        Assert.Equal("123", result);
    }

    [Fact]
    public void PartTwoTest()
    {
        var result = _day.PartTwo(_input);
        Assert.Equal("123", result);
    }
}
