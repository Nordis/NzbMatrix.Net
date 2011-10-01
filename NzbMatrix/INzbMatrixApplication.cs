using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NzbMatrix
{
    public interface INzbMatrixApplication
    {
        /// <summary>
        /// Your account username
        /// </summary>
        string Username { get; }

        /// <summary>
        /// Your API Key
        /// </summary>
        string ApiKey { get; }
    }
}
