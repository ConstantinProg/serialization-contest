namespace SerializationContest.PerformanceTests;

public record PerformanceTestResult(string testName, int IterationsNumber, TimeSpan TotalDuration)
{
    public override string ToString()
        => $"{testName}:\nTotal test duration: {TotalDuration.Milliseconds} milliseconds\nNumber of iterations: {IterationsNumber}";
}
