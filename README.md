``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.14393.2906 (1607/AnniversaryUpdate/Redstone1)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
Frequency=2062501 Hz, Resolution=484.8482 ns, Timer=TSC
.NET Core SDK=5.0.100
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT


```
|        Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated | Allocated native memory | Native memory leak |
|-------------- |------------:|----------:|----------:|-------:|------:|------:|----------:|------------------------:|-------------------:|
|         Part1 |    20.73 μs |  0.411 μs |  0.457 μs |      - |     - |     - |      40 B |                       - |                  - |
|         Part2 | 1,720.26 μs | 34.077 μs | 68.837 μs |      - |     - |     - |      40 B |                       - |                  - |
|    Part1_Linq |    11.86 μs |  0.236 μs |  0.299 μs | 0.0305 |     - |     - |     152 B |                       - |                  - |
|    Part2_Linq | 2,433.77 μs | 32.406 μs | 27.060 μs | 3.9063 |     - |     - |   25752 B |                    19 B |               19 B |
| Part2_HashSet |   911.78 μs | 14.880 μs | 22.272 μs | 5.8594 |     - |     - |   31408 B |                       - |                  - |
