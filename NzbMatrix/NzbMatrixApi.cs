﻿using System;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="category"></param>
        /// <param name="useHttps"></param>
        /// <param name="age"></param>
        /// <param name="maxHits"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Downloads a nzb file
        /// </summary>
        /// <param name="nzbId">NZB ID</param>
        /// <returns>Stream</returns>
        internal Stream DownloadNzb(int nzbId)
        {
            string downloadUrl = string.Format("http://api.nzbmatrix.com/v1.1/download.php?id={0}&username={1}&apikey={2}",
                                                        nzbId,
                                                        NzbMatrixApplication.Current.Username,
                                                        NzbMatrixApplication.Current.ApiKey);
            var stream = GetResponseStream(downloadUrl);

            return stream;
        }


        /// <summary>
        /// Makes a query to NzbMatrix with parameters
        /// </summary>
        /// <param name="page">Page to query with correct query string, e.g. search.php?search=</param>
        /// <param name="queryString">Other parameters to pass as query string</param>
        /// <param name="useHttps">Are we going to use https or not</param>
        /// <returns>Returns response as a string</returns>
        private string MakeQuery(string page, string queryString = "", bool useHttps = true)
        {
            string http = useHttps ? "https" : "http";

            const string searchUrl = "{0}://api.nzbmatrix.com/v1.1/{1}&username={2}&apikey={3}{4}";


            string queryUrl = string.Format(searchUrl, http, page,
                                            NzbMatrixApplication.Current.Username,
                                            NzbMatrixApplication.Current.ApiKey,
                                            queryString);

            var stream = GetResponseStream(queryUrl);

            var result = stream.ConvertToString();

            // Make sure we didn't receive an error
            result.TestForError();

            return result;
        }

        /// <summary>
        /// Gets response stream
        /// </summary>
        /// <param name="url">Request url</param>
        /// <returns>Stream</returns>
        private Stream GetResponseStream(string url)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            var stream = httpWebResponse.GetResponseStream();

            if (stream == null)
                throw new Exception("Response stream from NzbMatrix is null");

            return httpWebResponse.GetResponseStream();
        }
    }
}
