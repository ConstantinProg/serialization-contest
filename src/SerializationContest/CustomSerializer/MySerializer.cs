using System.Reflection;

namespace SerializationContest.CustomSerializer;

public class MySerializer(ISerializationFormat serializationFormat)
{
    public const BindingFlags BindingOptions = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

    public string Serialize(object serializedObject)
    {
        var serializationType = serializedObject.GetType();
        IEnumerable<SerializedMember> serializedMembers = serializationType.GetFields(BindingOptions).Select(fieldInfo => new SerializedMember(fieldInfo, serializedObject))
            .Union(serializationType.GetProperties(BindingOptions).Select(propertyInfo => new SerializedMember(propertyInfo, serializedObject)));
        return serializationFormat.Write(serializedMembers);
    }

    public T Deserialize<T>(string serializedData)
        where T : new()
    {
        var serializationType = typeof(T);
        var deserializedObject = (T)Activator.CreateInstance(serializationType)!;
        foreach (var serializedMember in serializationFormat.Read(serializedData))
        {
            var fieldInfo = deserializedObject.GetType().GetField(serializedMember.Name, BindingOptions);
            if (fieldInfo is not null)
            {
                fieldInfo.SetValue(deserializedObject, Convert.ChangeType(serializedMember.Value, fieldInfo.FieldType, null));
                continue;
            }
            var propertyInfo = deserializedObject.GetType().GetProperty(serializedMember.Name, BindingOptions);
            propertyInfo?.SetValue(deserializedObject, Convert.ChangeType(serializedMember.Value, propertyInfo.PropertyType, null));
        }
        return deserializedObject;
    }
}
