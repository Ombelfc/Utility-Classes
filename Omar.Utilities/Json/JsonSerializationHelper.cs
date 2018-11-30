using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Omar.Utilities.Json
{
    public static class JsonSerializationHelper
    {
        /// <summary>
        /// Serializes an anonymous object as a Json string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static StringContent AsJson(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
