using System.Reflection;

namespace SerializationContest.CustomSerializer;

public sealed class SerializedMember
{
    public string Name { get; init; }
    public string? Value { get; init; }

    public SerializedMember(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public SerializedMember(FieldInfo fieldInfo, object serializedObject)
    {
        ArgumentNullException.ThrowIfNull(serializedObject);
        Name = fieldInfo.Name;
        Value = fieldInfo.GetValue(serializedObject)?.ToString();
    }

    public SerializedMember(PropertyInfo propertyInfo, object serializedObject)
    {
        ArgumentNullException.ThrowIfNull(serializedObject);
        Name = propertyInfo.Name;
        Value = propertyInfo.GetValue(serializedObject)?.ToString();
    }
}