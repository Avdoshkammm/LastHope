using LastHope.Domain.Entities;
using LastHope.Domain.Interfaces;
using LastHope.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastHope.Infrastructure.Repositories
{
    public class ProductRepository : GenericInterface<Product>
    {
        private readonly LastHopeDBContext db;
        public ProductRepository(LastHopeDBContext _db)
        {
            db = _db;
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            List<Product> products = await db.Products.ToListAsync();
            return products;
        }
        public async Task<Product> GetProductAsync(int id)
        {
            Product product = await db.Products.FindAsync(id);
            return product;
        }
        public async Task CreateProductAsync(Product product)
        {
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }
    }
}
