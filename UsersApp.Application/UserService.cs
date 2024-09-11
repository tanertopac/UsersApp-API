using UsersApp.Domain;
using UsersApp.Domain.Exceptions;
using UsersApp.Infrastructure;

namespace UsersApp.Application;

public class UserService : IUserService
{
    IRepository<User> _Repository;

    public UserService(IRepository<User> userRepository)
    {
        _Repository = userRepository;
    }
    public async ValueTask<User> GetUserAsync(int id)
    {
        var user = await _Repository.GetById(id);
        if(user is null)
        {
            throw Errors.NotFound($"User with id: {id} is not found!");
        }
        return user;
    }
}

