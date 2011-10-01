using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NzbMatrix
{
    public class DefaultNzbMatrixApplication : INzbMatrixApplication
    {
        #region Implementation of INzbMatrixApplication

        /// <summary>
        /// Your account username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Your API Key
        /// </summary>
        public string ApiKey { get; set; }

        #endregion
    }
}
