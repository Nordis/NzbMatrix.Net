using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NzbMatrix
{
    public class NzbMatrixApplication
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly NzbMatrixApplication Instance = new NzbMatrixApplication();

        /// <summary>
        /// Current NzbMatrixApplication
        /// </summary>
        private INzbMatrixApplication _application;

        public NzbMatrixApplication()
        {
            _application = NzbMatrixConfigurationSection.Current;
        }

        /// <summary>
        /// Gets the current NzbMatrix application
        /// </summary>
        public static INzbMatrixApplication Current
        {
            get { return Instance.InnerCurrent; }
        }

        /// <summary>
        /// Sets the current NzbMatrixApplication
        /// </summary>
        /// <param name="nzbMatrixApplication">INzbMatrixApplication</param>
        public static void SetApplication(INzbMatrixApplication nzbMatrixApplication)
        {
            Instance.InnerSetApplication(nzbMatrixApplication);
        }

        /// <summary>
        /// Sets the current NzbMatrixApplication
        /// </summary>
        /// <param name="getNzbMatrixApplication">Get NzbMatrixApplication method</param>
        public static void SetApplication(Func<INzbMatrixApplication> getNzbMatrixApplication)
        {
            Instance.InnerSetApplication(getNzbMatrixApplication);
        }

        public INzbMatrixApplication InnerCurrent
        {
            get { return _application ?? new DefaultNzbMatrixApplication(); }
        }

        /// <summary>
        /// Sets the inner application
        /// </summary>
        /// <param name="nzbMatrixApplication">INzbMatrixApplication</param>
        public void InnerSetApplication(INzbMatrixApplication nzbMatrixApplication)
        {
            _application = nzbMatrixApplication;
        }

        /// <summary>
        /// Set the inner application
        /// </summary>
        /// <param name="getNzbMatrixApplication">Get NzbMatrixApplication method</param>
        public void InnerSetApplication(Func<INzbMatrixApplication> getNzbMatrixApplication)
        {
            _application = getNzbMatrixApplication();
        }
    }
}
