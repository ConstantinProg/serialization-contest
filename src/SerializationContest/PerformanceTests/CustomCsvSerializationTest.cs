using SerializationContest.CustomSerializer;
using SerializationContest.PerformanceTests.Samples;

namespace SerializationContest.PerformanceTests;

public class CustomCsvSerializationTest() : IPerformanceTest
{
    private MySerializer _serializer = new MySerializer(new CsvSerializationFormat());
    private object _serializedObject = F.Get();

    public string Name
        => "Custom csv serialization test";

    public void ExecuteTestOperations()
    => _serializer.Serialize(_serializedObject);
}
