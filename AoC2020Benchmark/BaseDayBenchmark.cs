using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    [MemoryDiagnoser]
    [KeepBenchmarkFiles(false)]
    public abstract class BaseDayBenchmark
    {
        public abstract string Part1();
        public abstract string Part2();
    }
}