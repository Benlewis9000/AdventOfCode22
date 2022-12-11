namespace Aoc.Core;

public class Problem : IProblem
{
    public int Year { get; }
    public int Day { get; }
    public int Part { get; }

    public Problem(int year, int day, int part)
    {
        if (ValidateYear(year)) Year = year;
        if (ValidateDay(day)) Day = day;
        if (ValidatePart(part)) Part = part;
    }

    // Validation does not prevent future dates from being entered. This is handled by the InputFetcher.

    private bool ValidateYear(int year)
    {
        if (year < 2015)
        {
            throw new ArgumentOutOfRangeException(nameof(year), $"problem year may not precede 2015, but was {year}");
        }

        return true;
    }

    private bool ValidateDay(int day)
    {
        if (day is < 0 or > 25)
        {
            throw new ArgumentOutOfRangeException(nameof(day),
                $"problem day must be between 1 and 25 inclusive, but was {day}");
        }

        return true;
    }

    private bool ValidatePart(int part)
    {
        if (part is < 1 or > 2)
        {
            throw new ArgumentOutOfRangeException(nameof(part), $"problem part may only be 1 or 2, but was {part}");
        }

        return true;
    }
}