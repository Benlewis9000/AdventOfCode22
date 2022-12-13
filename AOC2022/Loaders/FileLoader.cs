namespace Aoc.Core.Loaders;

internal class FileLoader : ILoader<string>
{
    private readonly string _path;

    public FileLoader(string path)
    {
        _path = path;
    }

    public string Load()
    {
        return File.ReadAllText(_path);
    }
}