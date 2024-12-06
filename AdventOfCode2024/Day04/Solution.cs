using AdventOfCode2024.Lib;

namespace AdventOfCode2024;

public class Day04 : IDay
{
    public string PartOne(string input)
    {
        var grid = ParseInput(input);

        var words = new[] { "XMAS", "SAMX" };
        var directions = new (int dy, int dx)[]
        {
            (0, 1), // right
            (1, 0), // down
            (1, 1), // diagonal down-right
            (-1, 1) // diagonal up-right
        };

        var rows = grid.Count;
        var cols = grid[0].Count;

        var count = 0;

        foreach (var word in words)
        {
            var length = word.Length;
            foreach (var (dy, dx) in directions)
                for (var y = 0; y < rows; y++)
                    for (var x = 0; x < cols; x++)
                    {
                        var endY = y + (length - 1) * dy;
                        var endX = x + (length - 1) * dx;

                        if (endY < 0 || endY >= rows || endX < 0 || endX >= cols)
                            continue;

                        var match = true;
                        for (var i = 0; i < length; i++)
                        {
                            var checkY = y + i * dy;
                            var checkX = x + i * dx;
                            if (grid[checkY][checkX] != word[i])
                            {
                                match = false;
                                break;
                            }
                        }

                        if (match) count++;
                    }
        }

        return count.ToString();
    }

    public string PartTwo(string input)
    {
        var grid = ParseInput(input);

        var rows = grid.Count;
        var cols = grid[0].Count;

        var count = 0;

        for (var y = 0; y < rows; y++)
            for (var x = 0; x < cols; x++)
            {
                if (y - 1 < 0 || y + 1 >= rows || x - 1 < 0 || x + 1 >= cols)
                    continue;

                if (grid[y][x] != 'A') continue;

                var topLeft = grid[y - 1][x - 1];
                var bottomRight = grid[y + 1][x + 1];
                var topRight = grid[y - 1][x + 1];
                var bottomLeft = grid[y + 1][x - 1];

                var diag1MAS = topLeft == 'M' && bottomRight == 'S';
                var diag1SAM = topLeft == 'S' && bottomRight == 'M';
                var diag2MAS = topRight == 'M' && bottomLeft == 'S';
                var diag2SAM = topRight == 'S' && bottomLeft == 'M';

                if ((diag1MAS || diag1SAM) && (diag2MAS || diag2SAM)) count++;
            }

        return count.ToString();
    }

    private static List<List<char>> ParseInput(string input)
    {
        return input.Trim()
            .Split('\n')
            .Select(line => line.ToCharArray().ToList())
            .ToList();
    }
}
