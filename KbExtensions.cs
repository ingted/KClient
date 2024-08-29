namespace NTDLS.Katzebase.Client
{
    public static class KbExtensions
    {
        public static List<T> MapTo<T>(this Payloads.KbQueryDocumentListResult result) where T : new()
        {
            var list = new List<T>();
            var properties = KbReflectionCache.GetProperties(typeof(T));

            foreach (var row in result.Rows)
            {
                var obj = new T();
                for (int i = 0; i < result.Fields.Count; i++)
                {
                    if (properties.TryGetValue(result.Fields[i].Name, out var property) && i < row.Values.Count)
                    {
                        var value = row.Values[i];
                        property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                    }
                }
                list.Add(obj);
            }

            return list;
        }
    }
}
