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

                        if (value == null)
                        {
                            if (property.PropertyType.IsValueType && Nullable.GetUnderlyingType(property.PropertyType) == null)
                            {
                                continue; // Skip setting value if property is non-nullable value type
                            }
                            else
                            {
                                property.SetValue(obj, null);
                            }
                        }
                        else
                        {
                            property.SetValue(obj, Convert.ChangeType(value, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType));
                        }
                    }
                }
                list.Add(obj);
            }

            return list;
        }

        public static Dictionary<string, KbConstant>? ToUserParametersDictionary(this object? parameters)
        {
            Dictionary<string, KbConstant>? result = null;
            if (parameters != null)
            {
                result = new();
                var type = parameters.GetType();

                foreach (var prop in type.GetProperties())
                {
                    var rawValue = prop.GetValue(parameters);
                    if (rawValue is string)
                    {
                        result.Add('@' + prop.Name, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.String));
                    }
                    else
                    {
                        if (rawValue == null || double.TryParse(rawValue?.ToString(), out _))
                        {
                            result.Add('@' + prop.Name, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.Numeric));
                        }
                        else
                        {
                            throw new Exception($"Non-string value of [{prop.Name}] cannot be converted to numeric.");
                        }
                    }
                }
            }

            return result;
        }

        public static KbInsensitiveDictionary<KbConstant>? ToUserParametersInsensitiveDictionary(this object? parameters)
        {
            KbInsensitiveDictionary<KbConstant>? result = null;
            if (parameters != null)
            {
                result = new();
                var type = parameters.GetType();

                foreach (var prop in type.GetProperties())
                {

                    var rawValue = prop.GetValue(parameters);
                    if (rawValue is string)
                    {
                        result.Add('@' + prop.Name, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.String));
                    }
                    else
                    {
                        if (rawValue == null || double.TryParse(rawValue?.ToString(), out _))
                        {
                            result.Add('@' + prop.Name, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.Numeric));
                        }
                        else
                        {
                            throw new Exception($"Non-string value of [{prop.Name}] cannot be converted to numeric.");
                        }
                    }
                }
            }
            return result;
        }

        public static KbInsensitiveDictionary<KbConstant>? ToUserParametersInsensitiveDictionary(this Dictionary<string, KbConstant> parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            var result = new KbInsensitiveDictionary<KbConstant>();
            foreach (var parameter in parameters)
            {
                result.Add(parameter.Key, parameter.Value);
            }
            return result;
        }
    }
}
