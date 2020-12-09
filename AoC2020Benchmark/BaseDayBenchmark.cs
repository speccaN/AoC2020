using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace AoC2020Benchmark
{
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    [MemoryDiagnoser]
    [KeepBenchmarkFiles(false)]
    [ShortRunJob(RuntimeMoniker.NetCoreApp50)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public abstract class BaseDayBenchmark
    {
        public abstract string Part1();
        public abstract string Part2();
    }
}