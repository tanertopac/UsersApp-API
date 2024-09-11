using System;
namespace UsersApp.Domain.Exceptions
{
	public static class Errors
	{
		public static NotFoundException NotFound(string message)
		{
			return new NotFoundException(message);
		}

        public static InternalServerException InternalServer(string message)
        {
            return new InternalServerException(message);
        }
    }
}

