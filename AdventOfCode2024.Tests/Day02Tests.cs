using AdventOfCode2024.Lib;

namespace AdventOfCode2024.Tests;

public class Day02Tests
{
    private readonly IDay _day;
    private readonly string _input;

    public Day02Tests()
    {
        _day = new Day02();
        _input = """
                 7 6 4 2 1
                 1 2 7 8 9
                 9 7 6 2 1
                 1 3 2 4 5
                 8 6 4 4 1
                 1 3 6 7 9
                 """;
    }

    [Fact]
    public void PartOneTest()
    {
        var result = _day.PartOne(_input);
        Assert.Equal("2", result);
    }

    [Fact]
    public void PartTwoTest()
    {
        var result = _day.PartTwo(_input);
        Assert.Equal("4", result);
    }
}
