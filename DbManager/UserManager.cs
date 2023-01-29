using Authentication.Entites; 
using ProductsWebAPI.Contexts;

namespace Authentication.Repositories
{
    public class UserManager : IUserManager
    {
        public bool Delete(int id)
        {
            using(var context = new CollectionContext())
            {
                context.users.Remove(context.users.Find(id));
                context.SaveChanges();
            }
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            using (var context = new CollectionContext())
            {
             var users = from prod in context.users select prod;
             return users.ToList<User>();
            }
        }

        public User GetById(int id)
        {
            using (var context = new CollectionContext())
            {
             var user = context.users.Find(id);
             return user;
            }
        }

        public bool Insert(User user)
        {
            using(var context = new CollectionContext())
            {
                context.users.Add(user);
                context.SaveChanges(); 
            }
            return true;
        }

        public bool Update(User user)
        {
            using(var context = new CollectionContext())
            {
                var theUser = context.users.Find(user.Id);
                theUser.FirstName =user.FirstName;
                theUser.LastName =user.LastName;
                theUser.Password =user.Password;
                theUser.Username =user.Username;
                context.SaveChanges();
            }
            return true;
        }
    }
}