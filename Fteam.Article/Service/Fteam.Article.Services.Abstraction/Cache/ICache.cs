using StackExchange.Redis;

namespace Fteam.Article.Services.Abstraction;

public interface ICache : IAsyncDisposable
{
    Task<TModel?> GetItemAsync<TModel>(string key);

    Task<TModel?> SetItemAsync<TModel>(string key, TModel? obj);

    Task<TModel?> SetItemAsync<TModel>(string key, TModel? obj, CacheDuration duration);

    Task<TModel?> SetItemIfAsync<TModel>(bool condition, string key, TModel? obj);

    Task<TModel?> SetItemIfAsync<TModel>(bool condition, string key, TModel? obj, CacheDuration duration);

    Task RemoveItemAsync(string key);

    Task<ConnectionMultiplexer?> ConnectAsync();

    Task<ConnectionMultiplexer?> ConnectAsync(string cnn);

    string GenerateKey(object[] objects);
}

public record CacheDuration(int Milliseconds = 0, int Second = 0, int Minute = 0, int Hour = 0, int Day = 0);
