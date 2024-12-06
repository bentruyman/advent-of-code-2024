using AdventOfCode2024.Lib;

namespace AdventOfCode2024.Tests;

public class Day04Tests
{
    private readonly IDay _day;
    private readonly string _input;

    public Day04Tests()
    {
        _day = new Day04();
        _input = """
                 MMMSXXMASM
                 MSAMXMSMSA
                 AMXSXMAAMM
                 MSAMASMSMX
                 XMASAMXAMM
                 XXAMMXXAMA
                 SMSMSASXSS
                 SAXAMASAAA
                 MAMMMXMMMM
                 MXMXAXMASX
                 """;
    }

    [Fact]
    public void PartOneTest()
    {
        var result = _day.PartOne(_input);
        Assert.Equal("18", result);
    }

    [Fact]
    public void PartTwoTest()
    {
        var result = _day.PartTwo(_input);
        Assert.Equal("9", result);
    }
}
