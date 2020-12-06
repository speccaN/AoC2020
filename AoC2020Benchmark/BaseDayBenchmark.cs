using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    [MemoryDiagnoser]
    [KeepBenchmarkFiles(false)]
    public abstract class BaseDayBenchmark
    {
        [Benchmark]
        public abstract string Part1();
        [Benchmark]
        public abstract string Part2();
    }
}