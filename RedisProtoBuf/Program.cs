using BenchmarkDotNet.Running;
using RedisProtoBuf.Tests;

var summary = BenchmarkRunner.Run<RedisCacheSet>();
