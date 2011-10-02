using System;

namespace NzbMatrix
{
    public class NzbMatrixException : Exception
    {
        public NzbMatrixException(string message) : 
            base(message) { }

        public NzbMatrixException(string message, Exception innerException) : 
            base(message,innerException) { }
    }
}
