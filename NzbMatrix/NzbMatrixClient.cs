using System;
using System.Collections.Generic;
using System.IO;
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
        
        public List<ISearchResponse> Search(string query, Categories category = Categories.All)
        {
            return _api.Search(query, category, true, -1, 5);
        }
        
        #endregion

        #region Download API
        
        public Stream DownloadNzbFile(int nzbId)
        {
            return _api.DownloadNzb(nzbId);
        }

        #endregion
    }
}
