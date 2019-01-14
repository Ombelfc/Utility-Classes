using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Omar.Utilities.Json
{
    public static class JsonPrintingHelper
    {
        public static string DumpAsJson(this IEnumerable obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
