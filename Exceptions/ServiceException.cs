using System;

namespace DIO.Bank.Exceptions
{
    class ServiceException : Exception
    {
        public ServiceException(string message) : base(message)
        {

        }
    }
}