using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NzbMatrix.Responses;
using Castle.Components.DictionaryAdapter;

namespace NzbMatrix.Parsers
{
    /// <summary>
    /// Class to parse response from NzbMatrix
    /// </summary>
    static class ResponseParser
    {
        private static DictionaryAdapterFactory factory = new DictionaryAdapterFactory();

        public static List<T> ParseSearchResponse<T>(string response)
        {
            var queryResults = new List<T>();
            
            if (!string.IsNullOrEmpty(response))
            {
                string[] results = response.Replace("\n", "").Split('|');

                Dictionary<string, string> valuePairs;

                foreach (string resultItem in results)
                {
                    valuePairs = new Dictionary<string, string>();

                    foreach (string property in resultItem.Split(';').ToList())
                    {
                        // Do workaround for dates in response

                        string[] propertyPair = property.Split(':');
                        if (propertyPair.Length == 2)
                            valuePairs.Add(propertyPair[0], propertyPair[1]);
                        else if (propertyPair.Length == 4)
                        {
                            var dateBuilder = new StringBuilder();
                            dateBuilder.Append(propertyPair[1]);
                            // Workaround to parse dates correctly
                            for (int i = 2; i < propertyPair.Length; i++)
                            {
                                dateBuilder.Append(":").Append(propertyPair[i]);
                            }
                            valuePairs.Add(propertyPair[0], dateBuilder.ToString());
                        }
                    }

                    if (valuePairs.Count != 0)
                    {
                        var wrapper = factory.GetAdapter<T>(valuePairs);
                        queryResults.Add(wrapper);
                    }
                }

            }

            return queryResults;
        }

        
    }

    public interface ISearchResult
    {
        int NZBID { get; set; }
        string NZBNAME { get; set; }
    }
}
