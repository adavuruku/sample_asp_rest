using StackExchange.Redis;

namespace BookStoreApi.Services
{
    

    public class RedisService
    {
        private readonly IDatabase _redisDb;

        private readonly string appkey = "BookService:";
        public RedisService(IConnectionMultiplexer redis) {
            _redisDb = redis.GetDatabase(); ;
        }

        public async Task SetValueAsync(string key, string value)
        {
            var redisKey = string.Concat(appkey, key);
            await _redisDb.StringSetAsync(redisKey, value);
        }

        public async Task SetValueWithExpirationAsync(string key, string value, TimeSpan expiration)
        {
            string redisKey = string.Concat(appkey, key);

            // Set the value with expiration asynchronously
            await _redisDb.StringSetAsync(redisKey, value, expiration);
        }

        public async Task SetHashFieldAsync(string key, string field, string value)
        {
            string redisKey = string.Concat(appkey, key);
            await _redisDb.HashSetAsync(redisKey, field, value);
        }

        public async Task SetHashWithExpirationAsync(string key, string field, string value, TimeSpan expiration)
        {
            var redisKey = string.Concat(appkey, key);

            // Set the hash field
            await _redisDb.HashSetAsync(redisKey, field, value);

            // Set expiration on the hash key
            await _redisDb.KeyExpireAsync(redisKey, expiration);
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _redisDb.StringGetAsync(string.Concat(appkey, key));
        }

        public async Task<string> GetHashFieldAsync(string key, string field)
        {
            var redisKey = string.Concat(appkey, key);
            return await _redisDb.HashGetAsync(redisKey, field);
        }
    }
}
