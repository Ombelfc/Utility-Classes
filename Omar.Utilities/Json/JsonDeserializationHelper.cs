using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Omar.Utilities.Json
{
    public static class JsonDeserializationHelper
    {
        /// <summary>
        /// Deserializes the content as an Enumerable of a compile-time type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static IEnumerable<T> DeserializeToObjects<T>(string content)
        {
            JsonSerializer serializer = new JsonSerializer();
            using(StringReader stringReader = new StringReader(content))
            {
                using(JsonTextReader jsonReader = new JsonTextReader(stringReader))
                {
                    jsonReader.SupportMultipleContent = true;
                    while (jsonReader.Read())
                    {
                        yield return serializer.Deserialize<T>(jsonReader);
                    }
                }
            }
        }

        /// <summary>
        /// Deserializes the content as a compile-time type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T DeserializeToObject<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Deserializes the content as a run-time type;
        /// </summary>
        /// <param name="content"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static dynamic DeserializeToObject(string content, Type type)
        {
            return (dynamic)JsonConvert.DeserializeObject(content, type);
        }
    }
}
