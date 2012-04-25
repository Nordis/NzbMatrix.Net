using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace NzbMatrix
{
    public sealed class NzbMatrixConfigurationSection : ConfigurationSection, INzbMatrixApplication
    {
        /// <summary>
        /// Current NzbMatrix settings stored in configuration file.
        /// </summary>
        private static INzbMatrixApplication _application;

        #region Implementation of INzbMatrixApplication

        /// <summary>
        /// Your account username
        /// </summary>
        [ConfigurationProperty("username", IsRequired = true)]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        /// <summary>
        /// Your API Key
        /// </summary>
        [ConfigurationProperty("apiKey", IsRequired = true)]
        public string ApiKey
        {
            get { return (string) this["apiKey"]; }
            set { this["apiKey"] = value; }
        }

        /// <summary>
        /// To use https or not
        /// </summary>
        [ConfigurationProperty("useHttps", IsRequired = true)]
        public bool UseHttps
        {
            get { return (bool)this["useHttps"]; }
            set { this["useHttps"] = value; }
        }

        #endregion

        internal static INzbMatrixApplication Current
        {
            get
            {
                if (_application == null)
                {
                    var config = ConfigurationManager.GetSection("nzbMatrixSettings");
                    if (config != null)
                        _application = config as INzbMatrixApplication;
                }
                return _application;
            }
        }
    }
}
