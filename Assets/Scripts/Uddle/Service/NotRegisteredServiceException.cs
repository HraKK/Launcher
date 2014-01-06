using System;

namespace Uddle.Service
{
    public class NotRegisteredServiceException : Exception
    {
        public NotRegisteredServiceException(string message)
            : base(message)
        {
        }
    }
}