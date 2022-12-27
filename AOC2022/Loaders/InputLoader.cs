using System.Reflection.Metadata.Ecma335;

namespace Aoc.Core.Loaders;

public class InputLoader : ILoader<string>
{
    private readonly IConfiguration _configuration;
    private readonly IProblem _problem;
    private readonly string _path;

    public InputLoader(IConfiguration configuration, IProblem problem)
    {
        _configuration = configuration;
        _problem = problem;
        _path = GeneratePath();
    }

    public string Load()
    {
        if (!File.Exists(_path))
        {
            throw new FileNotFoundException($"Could not find configuration file at\"{_path}\".");
        }

        try
        {
            string data = File.ReadAllText(_path);
            Console.WriteLine("Loaded input from local file.");
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"File \"{_path}\" could not be loaded: {ex.Message}" + Environment.NewLine +
                              "Attempting web download...");
        }

        try
        {
            HttpLoader httpLoader = new HttpLoader(_configuration, _problem);
            string data = httpLoader.Load();
            Console.WriteLine("Loaded input from web.");
            return data;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to load problem input from file and web with provided configuration.", ex);
        }
    }

    /// <summary>
    /// Generate path of form dir/year/day_n.txt, e.g. inputs/2015/day_1.txt
    /// </summary>
    /// <returns></returns>
    private string GeneratePath()
    {
        return $"{_configuration.InputsPath}{Path.DirectorySeparatorChar}{_problem.Year}{Path.DirectorySeparatorChar}day_{_problem.Day}.txt";
    }
}