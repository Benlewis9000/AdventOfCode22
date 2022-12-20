using System.Reflection.Metadata.Ecma335;

namespace Aoc.Core.Loaders;

public class InputLoader : ILoader<string>
{
    private readonly IConfiguration _configuration;
    private readonly string _path;

    public InputLoader(IConfiguration configuration)
    {
        _configuration = configuration;
        _path = GeneratePath();
    }

    public string Load()
    {
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
            HttpLoader httpLoader = new HttpLoader(_configuration);
            string data = httpLoader.Load();
            Console.WriteLine("Loaded input from web.");
            return data;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to load input from web with provided configuration.", ex);
        }
    }

    private string GeneratePath()
    {
        var problem = _configuration.Problem;
        // e.g. inputs/2015/day_1.txt
        return $"{_configuration.InputsPath}{Path.DirectorySeparatorChar}{problem.Year}{Path.DirectorySeparatorChar}day_{problem.Day}.txt";
    }
}