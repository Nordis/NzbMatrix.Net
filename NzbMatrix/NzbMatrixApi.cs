using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using NzbMatrix.Parsers;
using NzbMatrix.Responses;

namespace NzbMatrix
{
    internal class NzbMatrixApi
    {
        internal List<SearchResponse> Search(string query, Categories category)
        {
            return ResponseParser.ParseSearchResponse(MakeQuery("search.php?search=" + query));
        }

        private string MakeQuery(string page, string queryString = "")
        {
            // used to build entire input
            var sb = new StringBuilder();

            // used on each read operation
            var buf = new byte[8192];

            const string searchUrl = "https://api.nzbmatrix.com/v1.1/{0}&username={1}&apikey={2}{3}";


            string queryUrl = string.Format(searchUrl, page,
                                            NzbMatrixApplication.Current.Username,
                                            NzbMatrixApplication.Current.ApiKey,
                                            queryString);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(queryUrl);

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            var stream = httpWebResponse.GetResponseStream();

            if (stream == null)
                return null;

            int count = 0;
            string tempString = null;

            do
            {
                count = stream.Read(buf, 0, buf.Length);

                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);
                    sb.Append(tempString);
                }

            } while (count > 0);

            var result = sb.ToString();

            if (result.StartsWith("error"))
                throw new Exception(sb.ToString());

            return sb.ToString();
        }
    }
}
