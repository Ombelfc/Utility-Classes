using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Omar.Utilities.Json
{
    public static class JsonToObjectHelper
    {
        /// <summary>
        /// Parses stream's content.
        /// Content in the format: [ { "key": "Guid" } ]
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<Guid> ToGuidList(StreamReader reader, string key)
        {
            return JArray.Parse(reader.ReadToEnd()).Select(x => Guid.Parse((string)(x[key]))).ToList();
        }

        /// <summary>
        /// Parses the content of the string. 
        /// Content in the format: [ { "key": "Guid" } ].
        /// </summary>
        /// <param name="content"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<Guid> ToGuidList(string content, string key)
        {
            return JArray.Parse(content).Select(x => Guid.Parse((string)(x[key]))).ToList();
        }
    }
}
