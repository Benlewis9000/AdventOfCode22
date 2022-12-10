namespace Aoc.Core.Loaders;

internal class FileLoader : ILoader<string>, IAsyncLoader<string>
{
    private readonly string _path;

    public FileLoader(string path)
    {
        _path = path;
    }

    public string Load()
    {
        return DoLoad(path => File.ReadAllText(path));
    }

    public Task<string> LoadAsync()
    {
        return DoLoad(path => File.ReadAllTextAsync(path));
    }

    // Used to reading can optionally be async whilst reusing the rest DoLoad
    private delegate TU ReadFileFunc<TU>(string path);

    private TU DoLoad<TU>(ReadFileFunc<TU> read)
    {
        try
        {
            return read.Invoke(_path);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Could not find file at {_path}");
            throw;
        }
        catch (IOException)
        {
            Console.WriteLine($"Failed to read file at {_path}");
            throw;
        }
    }
}