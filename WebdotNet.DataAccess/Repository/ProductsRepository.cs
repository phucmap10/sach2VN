using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebdotNet.DataAccess.Data;
using WebdotNet.DataAccess.Repository.IRepository;
using WebdotNet.Models;
namespace WebdotNet.DataAccess.Repository
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Products products)
        {
            _db.Products.Update(products);
        }
    }
}
