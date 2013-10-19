using System;

namespace Application.Manager.Service
{
    public class NotRegisteredServiceException : Exception
    {
        public NotRegisteredServiceException(string message)
            : base(message)
        {
        }
    }
}