using Contract;
namespace BusinessLogic;



public class UserService : IService<User>
{
    private readonly IRepository<User> _userRepo;

    public UserService(IRepository<User> repository)
    {
         _userRepo = repository;
    }

    public int Create(User entity)
    {
        return _userRepo.Add(entity);
    }

    public bool Modify(User entity)
    {
        return _userRepo.Update(entity);
    }

    public bool Remove(User entity)
    {
        return _userRepo.Delete(entity);
    }

    public User RetrieveById(int id)
    {
        return _userRepo.GetById(id);
    }
}
