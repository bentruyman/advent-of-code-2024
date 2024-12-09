using AdventOfCode2024.Lib;

namespace AdventOfCode2024.Tests;

public class Day05Tests
{
    private readonly IDay _day;
    private readonly string _input;

    public Day05Tests()
    {
        _day = new Day05();
        _input = """
                 47|53
                 97|13
                 97|61
                 97|47
                 75|29
                 61|13
                 75|53
                 29|13
                 97|29
                 53|29
                 61|53
                 97|53
                 61|29
                 47|13
                 75|47
                 97|75
                 47|61
                 75|61
                 47|29
                 75|13
                 53|13

                 75,47,61,53,29
                 97,61,53,29,13
                 75,29,13
                 75,97,47,61,53
                 61,13,29
                 97,13,75,29,47
                 """;
    }

    [Fact]
    public void GetMiddleNumber()
    {
        int[] numbers = [1, 2, 3, 4, 5];
        var result = Day05.GetMiddleNumber(numbers);
        Assert.Equal(3, result);
    }

    [Fact]
    public void ParseInput()
    {
        var result = Day05.ParseInput(_input);
        var orderingRules = result.OrderingRules;
        var updates = result.Updates;

        Assert.Equal(21, orderingRules.Count);
        Assert.Equal((47, 53), orderingRules[0]);

        Assert.Equal(6, updates.Count);
        Assert.Equal([75, 47, 61, 53, 29], updates[0]);
    }

    [Fact]
    public void PartOneTest()
    {
        var result = _day.PartOne(_input);
        Assert.Equal("143", result);
    }

    [Fact]
    public void PartTwoTest()
    {
        var result = _day.PartTwo(_input);
        Assert.Equal("123", result);
    }
}
