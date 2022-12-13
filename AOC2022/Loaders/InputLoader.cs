using System.Reflection.Metadata.Ecma335;

namespace Aoc.Core.Loaders;

public class InputLoader : ILoader<string?>
{
    private readonly IConfiguration _configuration;
    private readonly string _path;

    public InputLoader(IConfiguration configuration)
    {
        _configuration = configuration;
        _path = GeneratePath();
    }

    private bool TryDoLoad(ILoader<string?> loader, out string? data)
    {
        data = default;
        try
        {
            return loader.TryLoad(out data);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return false;
        }
    }

    private string GeneratePath()
    {
        var problem = _configuration.Problem;
        // e.g. inputs/2015/day_1.txt
        return $"{_configuration.InputsPath}{Path.DirectorySeparatorChar}{problem.Year}{Path.DirectorySeparatorChar}day_{problem.Day}.txt";
    }

    public bool TryLoad(out string? data)
    {
        FileLoader fileLoader = new FileLoader(_path);
        if (TryDoLoad(fileLoader, out data))
        {
            Console.WriteLine("Loaded input from local file.");
            return true;
        }

        HttpLoader httpLoader = new HttpLoader(_configuration);
        if (TryDoLoad(httpLoader, out data))
        {
            Console.WriteLine("Loaded input from web.");
            return true;
        }

        return false;
    }
}