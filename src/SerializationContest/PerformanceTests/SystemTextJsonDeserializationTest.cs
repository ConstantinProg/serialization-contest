using SerializationContest.PerformanceTests.Samples;
using System.Text.Json;

namespace SerializationContest.PerformanceTests;

public class SystemTextJsonDeserializationTest : IPerformanceTest
{
    private string _serializationData = JsonSerializer.Serialize(F.Get());

    public string Name
        => "System.Text.Json deserialization test";

    public void ExecuteTestOperations()
        => JsonSerializer.Deserialize<F>(_serializationData);
}
