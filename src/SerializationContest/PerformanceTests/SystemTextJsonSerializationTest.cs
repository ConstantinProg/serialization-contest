using SerializationContest.PerformanceTests.Samples;
using System.Text.Json;

namespace SerializationContest.PerformanceTests;

public class SystemTextJsonSerializationTest : IPerformanceTest
{
    private object _serializationObject = F.Get();

    public string Name
        => "System.Text.Json serialization test";

    public void ExecuteTestOperations()
        => JsonSerializer.Serialize(_serializationObject);
}
