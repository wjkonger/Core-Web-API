using System;
using Contract;

namespace DataAccess;

public class UserRepository : IRepository<User>
{
    public int Add(User entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public User GetById(int id)
    {
        return new User { Email = "wjkonger@gmail.com", UserName = "Kong wei jun" };
    }

    public bool Update(User entity)
    {
        throw new NotImplementedException();
    }
}
