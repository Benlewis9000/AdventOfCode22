using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc.Core;

internal interface IProblem
{
    public int Year { get; }
    public int Day { get; }
    public int Part { get; }
}