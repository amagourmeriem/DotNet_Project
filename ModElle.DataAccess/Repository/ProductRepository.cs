using ModElle.DataAccess.Data;
using ModElle.DataAccess.Repository.IRepository;
using ModElle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModElle.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    { 
        
     private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }


        public void Update(Product obj)
        {
            var objFromDb= _db.Product.FirstOrDefault(u=>u.Id==obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.size = obj.size;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.color = obj.color;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
            
               
            }
        }
    }
}
