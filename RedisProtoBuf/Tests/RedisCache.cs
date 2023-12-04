using BenchmarkDotNet.Attributes;
using ConsoleApp3.ProtoContracts;
using ProtoBuf;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisProtoBuf.Tests
{
    public class RedisCache
    {
        string redisProtoBufKey;
        string redisJsonKey;
        AccountBoosts redisValue;
        IDatabase db;


        [GlobalSetup]
        public void GlobalSetup()
        {

            //Set keys
            redisProtoBufKey = "ProtoBuf";
            redisJsonKey = "Json";

            // Read source file
            string jsonString = File.ReadAllText("TestFiles\\Source.json");
            redisValue = JsonSerializer.Deserialize<AccountBoosts>(jsonString);

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");

            // Accessing the default Redis database
            db = redis.GetDatabase();
        }

        [Benchmark()]
        public void SetCacheProtoBuf()
        {
            using (var memoryStream = new MemoryStream())
            {
                Serializer.Serialize(memoryStream, redisValue);
                // Setting a key-value pair
                db.StringSet(redisProtoBufKey, RedisValue.CreateFrom(memoryStream));
            }
        }

        [Benchmark()]
        public void SetCacheJson()
        {
                string jsonValue = JsonSerializer.Serialize(redisValue);
                // Setting a key-value pair
                db.StringSet(redisJsonKey, jsonValue);            
        }

        [Benchmark()]
        public AccountBoosts GetCacheProtoBuf()
        {
            using (var ms = new MemoryStream((byte[])db.StringGet(redisProtoBufKey)))
            {
                return Serializer.Deserialize<AccountBoosts>(ms);
                
            }
        }

        [Benchmark()]
        public AccountBoosts GetCacheJson()
        {
            string jsonValue = db.StringGet(redisJsonKey);
            return JsonSerializer.Deserialize<AccountBoosts>(jsonValue);
        }
    }
}
