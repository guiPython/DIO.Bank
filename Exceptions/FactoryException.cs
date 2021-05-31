using System;

namespace DIO.Bank.Exceptions
{
    public class FactoryException : Exception
    {
        public FactoryException(string message) : base(message) { }
    }
}