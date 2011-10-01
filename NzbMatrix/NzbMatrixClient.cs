using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NzbMatrix.Responses;

namespace NzbMatrix
{
    public class NzbMatrixClient
    {
        private NzbMatrixApi _api;

        /// <summary>
        /// Initialize a new instance of the NzbMatrix client
        /// </summary>
        public NzbMatrixClient()
        {
            // Initialize an instance of the api
            _api = new NzbMatrixApi();
        }

        #region Search Api
        
        public List<SearchResponse> Search(string query, Categories category)
        {
            return _api.Search(query, category);
        }
        
        #endregion
    }
}
