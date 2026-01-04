namespace AdventOfCode;

internal static class InputLoader
{
    public static string[] LoadPuzzleInputByName(int year, int day)
    {
        var path = Path.Combine("puzzle_input", $"{year}", $"Day{day}.txt");
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Could not load puzzle input from path '{path}'. " +
                "Please make sure that the puzzle input is available.", path);
        }

        return File.ReadAllLines(path);
    }
}