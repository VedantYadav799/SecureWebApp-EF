using System;
using System.Collections.Generic;
using Authentication.Entites;

namespace Authentication.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<User> GetProducts();
         User GetProductById(int id);
        bool Insert(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}