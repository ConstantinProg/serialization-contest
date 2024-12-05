namespace SerializationContest.CustomSerializer;

public interface ISerializationFormat
{
    IEnumerable<SerializedMember> Read(string serializedData);
    string Write(IEnumerable<SerializedMember> serializableCollection);
}
