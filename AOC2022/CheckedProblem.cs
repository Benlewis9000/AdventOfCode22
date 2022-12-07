using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Core;

internal class CheckedProblem : IProblem
{
    public int Year { get; }
    public int Day { get; }
    public int Part { get; }


    public CheckedProblem(Problem problem)
    {
        if (ValidateYear(problem.Year)) Year = problem.Year;
        if (ValidateDay(problem.Day)) Day = problem.Day;
        if (ValidatePart(problem.Part)) Part = problem.Part;
    }

    // Validation does not prevent future dates from being entered. This is handled by the InputFetcher.

    private bool ValidateYear(int year)
    {
        if (year < 2015)
        {
            throw new ArgumentOutOfRangeException(nameof(year), "problem year may not precede 2015");
        }

        return true;
    }

    private bool ValidateDay(int day)
    {
        if (day is < 0 or > 25)
        {
            throw new ArgumentOutOfRangeException(nameof(day),
                "problem day must be between 1 and 25 inclusive");
        }

        return true;
    }

    private bool ValidatePart(int part)
    {
        if (part is < 1 or > 2)
        {
            throw new ArgumentOutOfRangeException(nameof(part), "problem part may only be 1 or 2");
        }

        return true;
    }
}