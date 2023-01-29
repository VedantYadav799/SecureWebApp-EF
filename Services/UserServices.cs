using Authentication.Entites;
using Authentication.Models;
using Authentication.Helpers;
using Authentication.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;  

namespace Authentication.Services{
    public class UserServices : IUserService
    {
        private readonly AppSettings _appsettings;
        private  IProductRepository _repo;
        public UserServices( IOptions<AppSettings> appSettings )
        {
            _appsettings = appSettings.Value;
            ProductRepository repository=new ProductRepository();
             this._repo = repository;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _repo.GetProducts().SingleOrDefault(x=> x.Username == model.Username && x.Password==model.Password);
            if(user==null)return null;

            var token = generateJwtToken(user);
            return new AuthenticateResponse(user,token);
        }

        public IEnumerable<User> GetAll()
        {
            return _repo.GetProducts();
        }

        public User GetById(int id)
        {
            return  _repo.GetProductById(id);
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}