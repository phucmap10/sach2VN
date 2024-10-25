using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdotNet.Models;

namespace WebdotNet.DataAccess.Repository.IRepository
{
    public interface IProductsRepository : IRepository<Products>
    {
        void Update(Products products);
    }
}
