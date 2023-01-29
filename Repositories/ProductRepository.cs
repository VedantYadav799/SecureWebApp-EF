using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Authentication.Entites;

namespace Authentication.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        IUserManager _uManager;
        

        public ProductRepository(){
            _uManager=new UserManager();
        }
        public IEnumerable<User> GetProducts()
        {
                return _uManager.GetAll();
        }
    
        public User GetProductById(int id)
        {
             return _uManager.GetById(id);
            
        }
        public bool Insert(User user){
        return  _uManager.Insert(user);
        }
        public bool Update(User user){
           
            return _uManager.Update(user);
        }
        
        public bool Delete(int id){
            
            return  _uManager.Delete(id);
            
        }
    }
}