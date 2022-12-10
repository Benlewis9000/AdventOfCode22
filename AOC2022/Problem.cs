namespace Aoc.Core;

public struct Problem : IProblem
{
    public int Year { get; }
    public int Day { get; }
    public int Part { get; }


    public Problem(int year, int day, int part)
    {
        Year = year;
        Day = day;
        Part = part;
    }
}