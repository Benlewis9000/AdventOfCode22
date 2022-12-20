namespace Aoc.Core.Loaders;

[Obsolete("Do not use. Currently only delegates work to File.ReadAllText. Will be removed if no real purpose is found.")]
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