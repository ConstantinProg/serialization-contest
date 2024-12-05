using SerializationContest.CustomSerializer;
using SerializationContest.PerformanceTests.Samples;

namespace SerializationContest.PerformanceTests;

public class CustomCsvDeserializationTest : IPerformanceTest
{
    private static MySerializer s_serializer = new MySerializer(new CsvSerializationFormat());
    private string _serializationData = s_serializer.Serialize(F.Get());

    public string Name
        => "Custom csv deserialization test";

    public void ExecuteTestOperations()
    => s_serializer.Deserialize<F>(_serializationData);
}
