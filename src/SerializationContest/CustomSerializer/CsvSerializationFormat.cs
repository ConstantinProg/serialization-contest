namespace SerializationContest.CustomSerializer;

public class CsvSerializationFormat : ISerializationFormat
{
    public IEnumerable<SerializedMember> Read(string serializedData)
    {
        if (string.IsNullOrEmpty(serializedData))
            return Enumerable.Empty<SerializedMember>();

        var lines = serializedData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        var memberDataList = new List<SerializedMember>();

        foreach (var line in lines)
        {
            var columns = line.Split(',');
            if (columns.Length == 2)
            {
                var name = columns[0].Trim();
                var value = columns[1].Trim();
                memberDataList.Add(new SerializedMember(name, value));
            }
        }
        return memberDataList;
    }

    public string Write(IEnumerable<SerializedMember> serializedMembers)
    {
        if (serializedMembers is null || !serializedMembers.Any())
            return string.Empty;

        var lines = serializedMembers.Select(member => $"{member.Name},{member.Value}");
        return string.Join(Environment.NewLine, lines);
    }
}