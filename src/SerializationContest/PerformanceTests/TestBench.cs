using System.Diagnostics;

namespace SerializationContest.PerformanceTests;

internal class TestBench
{
    private Stopwatch _stopwatch = new();

    public int IterationNumber { get; set; } = 100000;

    public PerformanceTestResult TestPerformance(IPerformanceTest test)
    {
        _stopwatch.Restart();
        for (int i = 0; i < IterationNumber; i++)
            test.ExecuteTestOperations();
        _stopwatch.Stop();
        return new PerformanceTestResult($"{test.Name}", IterationNumber, _stopwatch.Elapsed);
    }

}
