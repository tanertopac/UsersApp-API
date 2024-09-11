using UsersApp.Domain;
namespace UsersApp.Infrastructure;

public class UserRepository : IRepository<User>
{
    private AppDbContext _Context;

    public UserRepository(AppDbContext context) {
        _Context = context;
    }

    public async ValueTask<User?> GetById(int id)
    {
        var user = await _Context.Users.FindAsync(id);
        return user;
    }
}

