using System;
using UsersApp.Domain;

namespace UsersApp.Application
{
	public interface IUserService
	{
        ValueTask<User> GetUserAsync(int id);
    }
}

