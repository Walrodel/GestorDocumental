using System;

namespace GestorDocumental.Core.Exceptions
{
    public class BusinessExeption : Exception
    {
        public BusinessExeption()
        {

        }

        public BusinessExeption(string message) : base(message)
        {

        }
    }
}
