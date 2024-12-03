using AdventOfCode2024.Lib;

namespace AdventOfCode2024.Tests;

public class Day03Tests
{
    private readonly IDay _day;

    public Day03Tests()
    {
        _day = new Day03();
    }

    [Fact]
    public void PartOneTest()
    {
        var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        var result = _day.PartOne(input);
        Assert.Equal("161", result);
    }

    [Fact]
    public void PartTwoTest()
    {
        var input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        var result = _day.PartTwo(input);
        Assert.Equal("48", result);
    }
}
