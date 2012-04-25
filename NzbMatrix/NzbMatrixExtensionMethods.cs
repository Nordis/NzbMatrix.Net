using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NzbMatrix
{
    public static class NzbMatrixExtensionMethods
    {
        public static string ConvertToString(this Stream stream)
        {
            var sb = new StringBuilder();
            var buf = new byte[8192];

            // Make a copy of the stream so we don't have to use the original stream
            Stream copyStream = stream;
            //stream.CopyTo(copyStream);

            int count = 0;
            string tempString = null;

            do
            {
                count = copyStream.Read(buf, 0, buf.Length);

                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);
                    sb.Append(tempString);
                }

            } while (count > 0);

            return sb.ToString();
        }

        public static void TestForError(this string content)
        {
            if (content.StartsWith("error"))
                throw new NzbMatrixException(content);
        }

        public static T ToEnumSafe<T>(this string value, bool ignoreCase = true)
            where T : struct
        {
            T result;
            return Enum.TryParse(value, ignoreCase, out result) ? result : default(T);
        }
    }
}
