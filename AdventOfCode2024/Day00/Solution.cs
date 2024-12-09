using AdventOfCode2024.Lib;

namespace AdventOfCode2024;

/**
 * TODO: Should probably have more error handling/checking. The input parsing assumes that the input is valid (which is probably fine).
 */
public class Day05 : IDay
{
    public string PartOne(string input)
    {
        var parsedInput = ParseInput(input);
        var sum = 0;

        foreach (var update in parsedInput.Updates)
            if (IsCorrectlyOrdered(update, parsedInput.OrderingRules))
                sum += GetMiddleNumber(update);

        return sum.ToString();
    }

    public string PartTwo(string input)
    {
        var parsedInput = ParseInput(input);
        var sum = 0;

        foreach (var update in parsedInput.Updates)
            if (!IsCorrectlyOrdered(update, parsedInput.OrderingRules))
            {
                var reordered = ReorderUpdate(update, parsedInput.OrderingRules);
                sum += GetMiddleNumber(reordered);
            }

        return sum.ToString();
    }

    public static int GetMiddleNumber(int[] numbers)
    {
        var middle = numbers.Length / 2;
        return numbers[middle];
    }

    public static Input ParseInput(string input)
    {
        var sections = input.Trim().Split("\n\n");
        List<(int, int)> orderingRules = [];
        var orderingRulesSection = sections[0].Split('\n');
        foreach (var line in orderingRulesSection)
        {
            var parts = line.Split('|');
            var tuple = (int.Parse(parts[0]), int.Parse(parts[1]));
            orderingRules.Add(tuple);
        }

        List<int[]> updates = [];
        foreach (var update in sections[1].Split('\n'))
        {
            var numbers = update.Split(',').Select(int.Parse).ToArray();
            updates.Add(numbers);
        }

        return new Input(orderingRules, updates);
    }

    private static bool IsCorrectlyOrdered(int[] update, List<(int, int)> rules)
    {
        var pageIndices = update
            .Select((page, index) => new { page, index })
            .ToDictionary(x => x.page, x => x.index);

        foreach (var (before, after) in rules)
            if (pageIndices.ContainsKey(before) && pageIndices.ContainsKey(after))
                if (pageIndices[before] > pageIndices[after])
                    return false;

        return true;
    }

    private static int[] ReorderUpdate(int[] update, List<(int, int)> rules)
    {
        var relevantRules = rules.Where(rule => update.Contains(rule.Item1) && update.Contains(rule.Item2)).ToList();

        var adjacencyList = new Dictionary<int, List<int>>();
        var inDegree = new Dictionary<int, int>();

        foreach (var page in update)
        {
            adjacencyList[page] = [];
            inDegree[page] = 0;
        }

        foreach (var (before, after) in relevantRules)
        {
            adjacencyList[before].Add(after);
            inDegree[after]++;
        }

        var queue = new Queue<int>();
        foreach (var page in inDegree.Keys)
            if (inDegree[page] == 0)
                queue.Enqueue(page);

        var sorted = new List<int>();

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            sorted.Add(current);

            foreach (var neighbor in adjacencyList[current])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }

        return sorted.ToArray();
    }

    public readonly struct Input(List<(int, int)> orderingRules, List<int[]> updates)
    {
        public List<(int, int)> OrderingRules { get; } = orderingRules;
        public List<int[]> Updates { get; } = updates;
    }
}
