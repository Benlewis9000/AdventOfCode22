namespace Aoc.Core.Loaders;

internal class FileLoader : ILoader<string?>
{
    private readonly string _path;

    public FileLoader(string path)
    {
        _path = path;
    }

    public bool TryLoad(out string? data)
    {
        return TryDoLoad(File.ReadAllText, out data);
    }

    // Used to reading can optionally be async whilst reusing the rest DoLoad, should such a method be added
    // (was previously removed)
    private delegate T ReadFileFunc<out T>(string path);

    private bool TryDoLoad<T>(ReadFileFunc<T?> read, out T? data)
    {
        data = default;
        try
        {
            data = read.Invoke(_path);
            return true;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Could not find file at {_path}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Failed to read file at {_path}");
            Console.WriteLine(ex);
        }

        return false;
    }
}