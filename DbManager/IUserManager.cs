using Authentication.Entites;

namespace Authentication.Repositories
{
    public interface IUserManager
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        bool Insert(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}