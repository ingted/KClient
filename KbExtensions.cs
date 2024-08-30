using NTDLS.Katzebase.Client.Types;

namespace NTDLS.Katzebase.Client
{
    public static class KbExtensions
    {
        public static IEnumerable<T> MapTo<T>(this Payloads.KbQueryDocumentListResult result) where T : new()
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

        public static KbInsensitiveDictionary<string?>? ToUserParameters(this object? userParameters)
        {
            KbInsensitiveDictionary<string?>? userParameterValues = null;
            if (userParameters != null)
            {
                userParameterValues = new();
                var type = userParameters.GetType();

                foreach (var prop in type.GetProperties())
                {
                    var rawValue = prop.GetValue(userParameters)?.ToString();

                    if (double.TryParse(rawValue, out _))
                    {
                        userParameterValues.Add('@' + prop.Name, rawValue);
                    }
                    else
                    {
                        userParameterValues.Add('@' + prop.Name, $"'{rawValue}'");
                    }
                }
            }

            return userParameterValues;
        }
    }
}
