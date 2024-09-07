﻿using NTDLS.Katzebase.Client.Types;

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

        public static Dictionary<string, string?>? ToUserParametersDictionary(this object? value)
        {
            Dictionary<string, string?>? userParameterValues = null;
            if (value != null)
            {
                userParameterValues = new();
                var type = value.GetType();

                foreach (var prop in type.GetProperties())
                {
                    var rawValue = prop.GetValue(value)?.ToString();

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

        public static KbInsensitiveDictionary<string?>? ToUserParametersInsensitiveDictionary(this object? value)
        {
            KbInsensitiveDictionary<string?>? userParameterValues = null;
            if (value != null)
            {
                userParameterValues = new();
                var type = value.GetType();

                foreach (var prop in type.GetProperties())
                {
                    var rawValue = prop.GetValue(value)?.ToString();

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

        public static KbInsensitiveDictionary<string?>? ToUserParametersInsensitiveDictionary(this Dictionary<string, string?> value)
        {
            if (value == null)
            {
                return null;
            }

            var userParameterValues = new KbInsensitiveDictionary<string?>();
            foreach (var val in value)
            {
                userParameterValues.Add(val.Key, val.Value);
            }
            return userParameterValues;
        }
    }
}
