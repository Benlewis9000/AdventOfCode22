namespace Aoc.Core.Loaders;

internal interface IAsyncLoader<T>
{
    Task<T> LoadAsync();
}