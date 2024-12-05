namespace SerializationContest.PerformanceTests;

public interface IPerformanceTest
{
    string Name { get; }
    void ExecuteTestOperations();
}
