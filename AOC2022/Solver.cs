using Aoc.Core.Loaders;

namespace Aoc.Core;

public class Solver
{
    private readonly Solution _solution;

    private readonly string _input;

    public Solver(string configurationPath, IProblem problem, Solution solution)
    {
        _solution = solution;
        var configuration = new ConfigurationLoader(configurationPath).Load();
        _input = new InputLoader(configuration, problem).Load();
    }

    public string Solve()
    {
        return _solution(_input);
    }
}