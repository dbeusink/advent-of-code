namespace AdventOfCode;

internal abstract class PuzzleBase
{
    public string Name { get; }
    public int Year { get; }
    public int Day { get; }
    public bool IsLongRunning { get; }
    protected string[] Input { get; private set; }

    protected PuzzleBase(int year, int day, bool longRunning = false)
    {
        Year = year;
        Day = day;
        Name = $"{year}.{day}";
        IsLongRunning = longRunning;
    }

    public void Initialize()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new InvalidDataException("Could not initialize puzzle because it's name is not set.");
        }

        Input = InputLoader.LoadPuzzleInputByName(Year, Day);
        Console.WriteLine($"Puzzle \u001b[1;92m'{Name}'\u001b[0m: Read \u001b[1;95m{Input.Length}\u001b[0m lines as puzzle input");
    }

    protected void AssertInputLoaded()
    {
        if (Input.Length == 0)
        {
            throw new InvalidOperationException($"The input for puzzle '{Name}' is not loaded!");
        }
    }

    public abstract string SolvePart1();

    public abstract string SolvePart2();
}