using System;

namespace DIO.Bank.Exceptions
{
    class EntityException : Exception
    {
        public EntityException(string message) : base(message)
        {

        }
    }
}