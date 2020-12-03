using BenchmarkDotNet.Attributes;

namespace AoC2020Benchmark
{
    [MarkdownExporterAttribute.GitHub]
    [HtmlExporter]
    [KeepBenchmarkFiles(false)]
    public class BaseDayBenchmark
    {
    }
}