using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Omar.Utilities.Streams
{
    public static class StreamToArrayHelper
    {
        /// <summary>
        /// Returns all bytes in a given Stream using the CopyTo method. Might have a performance issue.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadAllBytes(Stream stream)
        {
            if (stream is MemoryStream)
                return ((MemoryStream)stream).ToArray();

            using (var mStream = new MemoryStream())
            {
                stream.CopyTo(mStream);
                return mStream.ToArray();
            }
        }
    }
}
