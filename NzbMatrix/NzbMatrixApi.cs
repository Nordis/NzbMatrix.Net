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
        internal List<ISearchResponse> Search(string query, Categories category, bool useHttps = true, int age = -1, int maxHits = 15)
        {
            var queryStringBuilder = new StringBuilder();

            // Format age parameter
            if (age > -1)
                queryStringBuilder.Append(string.Format("&age={0}", age));

            queryStringBuilder.Append(string.Format("&maxhits={0}", maxHits));

            return ResponseParser.ParseSearchResponse<ISearchResponse>(
                                    MakeQuery("search.php?search=" + query, 
                                    queryStringBuilder.ToString(), 
                                    useHttps));
        }

        private string MakeQuery(string page, string queryString = "", bool useHttps = true)
        {
            var sb = new StringBuilder();
            var buf = new byte[8192];

            string http = useHttps ? "https" : "http";

            const string searchUrl = "{0}://api.nzbmatrix.com/v1.1/{1}&username={2}&apikey={3}{4}";


            string queryUrl = string.Format(searchUrl, http, page,
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
                throw new NzbMatrixException(sb.ToString());

            return sb.ToString();
        }
    }
}
