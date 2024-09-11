using System;
namespace UsersApp.Domain.Exceptions
{
	public class InternalServerException : Exception
	{
        public InternalServerException(string message) : base(message) { }
    }
}

