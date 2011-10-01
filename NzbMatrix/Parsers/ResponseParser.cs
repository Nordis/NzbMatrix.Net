using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NzbMatrix.Responses;

namespace NzbMatrix.Parsers
{
    /// <summary>
    /// Class to parse response from NzbMatrix
    /// </summary>
    static class ResponseParser
    {
        public static List<SearchResponse> ParseSearchResponse(string response)
        {
            var searchResults = new List<SearchResponse>();
            
            if (!string.IsNullOrEmpty(response))
            {
                string[] results = response.Replace("\n", "").Split('|');

                Dictionary<string, string> valuePairs;

                foreach (string resultItem in results)
                {
                    valuePairs = new Dictionary<string, string>();

                    foreach (string property in resultItem.Split(';').ToList())
                    {
                        string[] propertyPair = property.Split(':');
                        if (propertyPair.Length == 2)
                            valuePairs.Add(propertyPair[0], propertyPair[1]);
                    }

                    if (valuePairs.Count != 0)
                        searchResults.Add(new SearchResponse(valuePairs));
                }

            }

            return searchResults;
        }
    }
}
