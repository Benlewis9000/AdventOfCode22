namespace Aoc.Core.Loaders;

public interface ILoader<T>
{
    public T Load();
}