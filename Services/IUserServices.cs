using Authentication.Entites;
using Authentication.Models;
namespace Authentication.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        
    }
}