using BenchmarkDotNet.Running;
using StringConcatenationBenchmark.Tests;

BenchmarkRunner.Run<StringConcatenation>();

Console.Read();