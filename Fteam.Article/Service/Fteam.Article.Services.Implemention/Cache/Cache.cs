using StackExchange.Redis;

namespace Fteam.Article.Services.Implementation;

public class Cache : ICache
{
    readonly IConfiguration _configuration;

    public Cache(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<ConnectionMultiplexer?> ConnectAsync()
    {
        var redisConnection = _configuration["Cache:Redis:Connection"];
        return await ConnectAsync(redisConnection ?? "");
    }

    public async Task<ConnectionMultiplexer?> ConnectAsync(string cnn)
    {
        try
        {
            return await ConnectionMultiplexer.ConnectAsync(cnn);
        }
        catch
        {
            return null;
        }
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return ValueTask.CompletedTask;
    }

    public string GenerateKey(object[] objects) => string.Join("-", objects);

    public async Task<TModel?> GetItemAsync<TModel>(string key)
    {
        try
        {
            var connection = await ConnectAsync();
            _ = int.TryParse(_configuration["Cache:Redis:Db"], out int dbInstance);
            if (connection == null)
                return default;

            IDatabase db = connection.GetDatabase(dbInstance);
            RedisValue value = await db.StringGetAsync(key);

            await connection.CloseAsync();
            connection.Dispose();

            return JsonConvert.DeserializeObject<TModel>(value.ToString());
        }
        catch
        {
            return default;
        }
    }

    public async Task RemoveItemAsync(string key)
    {
        try
        {
            var connection = await ConnectAsync();
            _ = int.TryParse(_configuration["Cache:Redis:Db"], out int dbInstance);
            if (connection == null)
                return;

            IDatabase db = connection.GetDatabase(dbInstance);
            await db.StringGetDeleteAsync(key);

            await connection.CloseAsync();
            connection.Dispose();
            return;
        }
        catch
        {
            return;
        }
    }

    public async Task<TModel?> SetItemAsync<TModel>(string key, TModel? obj)
        => await SetItemAsync(key, obj, cacheTime: null);

    public async Task<TModel?> SetItemAsync<TModel>(string key, TModel? obj, CacheDuration duration)
    {
        TimeSpan timeSpan = new(duration.Day, duration.Hour, duration.Minute, duration.Second, duration.Milliseconds);

        return await SetItemAsync(key, obj, timeSpan);
    }

    public async Task<TModel?> SetItemIfAsync<TModel>(bool condition, string key, TModel? obj)
            => condition ? await SetItemAsync(key, obj) : default;

    public async Task<TModel?> SetItemIfAsync<TModel>(bool condition, string key, TModel? obj, CacheDuration duration)
            => condition ? await SetItemAsync(key, obj, duration) : default;

    async Task<TModel?> SetItemAsync<TModel>(string key, TModel? obj, TimeSpan? cacheTime)
    {
        try
        {
            var connection = await ConnectAsync();
            _ = int.TryParse(_configuration["Cache:Redis:Db"], out int dbInstance);
            if (connection == null)
                return default;

            IDatabase db = connection.GetDatabase(dbInstance);
            string json = JsonConvert.SerializeObject(obj);
            var res = await db.StringSetAsync(key, new RedisValue(json), cacheTime) ?
                    obj : default;

            await connection.CloseAsync();
            connection.Dispose();

            return res;
        }
        catch
        {
            return default;
        }
    }
}
