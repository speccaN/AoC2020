``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|        Method |         Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |-------------:|----------:|----------:|-------:|------:|------:|----------:|
|         Part1 |    16.392 μs | 0.0132 μs | 0.0117 μs |      - |     - |     - |      40 B |
|         Part2 | 1,319.479 μs | 5.3382 μs | 4.9933 μs |      - |     - |     - |      40 B |
|    Part1_Linq |     9.159 μs | 0.0039 μs | 0.0030 μs | 0.0153 |     - |     - |     152 B |
|    Part2_Linq | 1,874.864 μs | 6.8511 μs | 6.4085 μs | 3.9063 |     - |     - |   25752 B |
| Part2_HashSet |   691.769 μs | 0.3471 μs | 0.3247 μs | 4.8828 |     - |     - |   31408 B |
