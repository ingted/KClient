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

        public static Dictionary<string, KbConstant>? ToUserParametersDictionary(this object? value)
        {
            Dictionary<string, KbConstant>? userParameterValues = null;
            if (value != null)
            {
                userParameterValues = new();
                var type = value.GetType();

                foreach (var prop in type.GetProperties())
                {
                    var rawValue = prop.GetValue(value);
                    if (rawValue is string)
                    {
                        userParameterValues.Add('@' + prop.Name, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.String));
                    }
                    else
                    {
                        if (rawValue == null || double.TryParse(rawValue?.ToString(), out _))
                        {
                            userParameterValues.Add('@' + prop.Name, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.Numeric));
                        }
                        else
                        {
                            throw new Exception($"Non-string value of [{prop.Name}] cannot be converted to numeric.");
                        }
                    }
                }
            }

            return userParameterValues;
        }

        public static KbInsensitiveDictionary<KbConstant>? ToUserParametersInsensitiveDictionary(this object? value)
        {
            KbInsensitiveDictionary<KbConstant>? userParameterValues = null;
            if (value != null)
            {
                userParameterValues = new();
                var type = value.GetType();

                foreach (var prop in type.GetProperties())
                {

                    var rawValue = prop.GetValue(value);
                    if (rawValue is string)
                    {
                        userParameterValues.Add('@' + prop.Name, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.String));
                    }
                    else
                    {
                        if (rawValue == null || double.TryParse(rawValue?.ToString(), out _))
                        {
                            userParameterValues.Add('@' + prop.Name, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.Numeric));
                        }
                        else
                        {
                            throw new Exception($"Non-string value of [{prop.Name}] cannot be converted to numeric.");
                        }
                    }
                }
            }
            return userParameterValues;
        }

        public static KbInsensitiveDictionary<KbConstant>? ToUserParametersInsensitiveDictionary(this Dictionary<string, object?> parameters)
        {
            if (parameters == null)
            {
                return null;
            }

            var userParameterValues = new KbInsensitiveDictionary<KbConstant>();
            foreach (var parameter in parameters)
            {
                var rawValue = parameter.Value;
                if (rawValue is string)
                {
                    userParameterValues.Add('@' + parameter.Key, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.String));
                }
                else
                {
                    if (rawValue == null || double.TryParse(rawValue?.ToString(), out _))
                    {
                        userParameterValues.Add('@' + parameter.Key, new KbConstant(rawValue?.ToString(), KbConstants.KbBasicDataType.Numeric));
                    }
                    else
                    {
                        throw new Exception($"Non-string value of [{parameter.Key}] cannot be converted to numeric.");
                    }
                }
            }
            return userParameterValues;
        }
    }
}
