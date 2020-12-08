``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.630 (2004/?/20H1)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.100
  [Host]                 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  ShortRun-.NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=ShortRun-.NET Core 5.0  Runtime=.NET Core 5.0  IterationCount=3  
LaunchCount=1  WarmupCount=3  

```

### Day 1
|        Method |         Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |-------------:|----------:|----------:|-------:|------:|------:|----------:|
|         Part1 |    17.843 μs | 0.2759 μs | 0.2581 μs |      - |     - |     - |      40 B |
|         Part2 | 1,301.842 μs | 0.7037 μs | 0.6582 μs |      - |     - |     - |      40 B |
|    Part1_Linq |     8.912 μs | 0.0111 μs | 0.0086 μs | 0.0153 |     - |     - |     152 B |
|    Part2_Linq | 1,857.475 μs | 3.0210 μs | 2.6781 μs | 3.9063 |     - |     - |   25752 B |
| Part2_HashSet |   694.778 μs | 0.6397 μs | 0.5670 μs | 4.8828 |     - |     - |   31408 B |

### Day 2
| Method |      Mean |    Error |   StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------- |----------:|---------:|---------:|--------:|------:|------:|----------:|
|  Part1 | 126.85 μs | 0.189 μs | 0.177 μs | 19.0430 |     - |     - |  120032 B |
|  Part2 |  12.12 μs | 0.024 μs | 0.023 μs |       - |     - |     - |      32 B |

### Day 3
| Method |      Mean |    Error |   StdDev |      Gen 0 |     Gen 1 | Gen 2 | Allocated |
|------- |----------:|---------:|---------:|-----------:|----------:|------:|----------:|
|  Part1 |  50.82 ms | 0.367 ms | 0.343 ms |  7700.0000 |  900.0000 |     - |  46.23 MB |
|  Part2 | 228.16 ms | 1.451 ms | 1.358 ms | 34666.6667 | 4333.3333 |     - | 208.14 MB |

### Day 4
| Method |     Mean |   Error |  StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------- |---------:|--------:|--------:|--------:|------:|------:|----------:|
|  Part1 | 320.4 μs | 0.39 μs | 0.36 μs | 80.0781 |     - |     - | 492.55 KB |
|  Part2 | 362.8 μs | 0.39 μs | 0.36 μs | 76.6602 |     - |     - | 470.63 KB |

### Day 5
| Method |     Mean |   Error |  StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------- |---------:|--------:|--------:|-------:|------:|------:|----------:|
|  Part1 | 166.1 μs | 0.10 μs | 0.09 μs | 7.3242 |     - |     - |  45.63 KB |
|  Part2 | 186.7 μs | 0.23 μs | 0.21 μs | 7.3242 |     - |     - |   45.8 KB |

### Day 6
| Method |     Mean |   Error |  StdDev |    Gen 0 | Gen 1 | Gen 2 |  Allocated |
|------- |---------:|--------:|--------:|---------:|------:|------:|-----------:|
|  Part1 | 303.2 μs | 0.42 μs | 0.39 μs |  67.8711 |     - |     - |  418.32 KB |
|  Part2 | 675.3 μs | 1.28 μs | 1.20 μs | 168.9453 |     - |     - | 1038.78 KB |

### Day 7
| Method |       Mean |     Error |   StdDev |    Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------- |-----------:|----------:|---------:|---------:|--------:|------:|----------:|
|  Part1 | 7,778.8 μs | 453.98 μs | 24.88 μs | 148.4375 | 70.3125 |     - | 956.35 KB |
|  Part2 |   728.0 μs |  16.86 μs |  0.92 μs | 141.6016 | 62.5000 |     - | 867.97 KB |
