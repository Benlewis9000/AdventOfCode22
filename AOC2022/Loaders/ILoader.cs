namespace Aoc.Core.Loaders;

public interface ILoader<T>
{
    public bool TryLoad(out T data);
}