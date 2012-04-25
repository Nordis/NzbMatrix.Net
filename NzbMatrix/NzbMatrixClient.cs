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
            return _api.Search(query, category);
        }

        public List<ISearchResponse> Search(string query, int maxHits, Categories category = Categories.All, int age = -1)
        {
            return _api.Search(query, category, age, maxHits);
        }

        #endregion

        #region Download API
        
        public Stream DownloadNzbFile(int nzbId)
        {
            return _api.DownloadNzb(nzbId);
        }

        #endregion

        #region Post Details API

        public IPostDetailsResponse GetPostDetails(int nzbId)
        {
            return _api.GetPostDetails(nzbId);
        }

        #endregion

        #region Account API

        public IAccountResponse GetAccountDetails()
        {
            return _api.GetAccountDetails();
        }

        #endregion

        #region Bookmarks API

        public BookmarkCode AddBookmark(int nzbId)
        {
            return _api.Bookmark(BookmarkAction.Add, nzbId);
        }

        public BookmarkCode RemoveBookmark(int nzbId)
        {
            return _api.Bookmark(BookmarkAction.Remove, nzbId);
        }

        #endregion
    }
}
