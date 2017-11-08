using HPlusSportsAPITwo.Contracts;
using HPlusSportsAPITwo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPITwo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private H_Plus_SportsContext db;
        private IMemoryCache cache;

        public ProductRepository(H_Plus_SportsContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
        }

        public IEnumerable<Product> GetAll() => db.Product;

        public void Add(Product item)
        {
            db.Product.Add(item);
            cache.Set(item.ProductId, item, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)

            });
            db.SaveChanges();
        }

        //public Product Find(string key) => db.Product.Include(product => product.OrderItem).SingleOrDefault(a => a.ProductId == key);
        public Product Find(string key)
        {
            Product cachedProduct = null;
            if(cache.TryGetValue(key, out cachedProduct))
            {
                return cachedProduct;
            }
            else
            {
                var item = db.Product.Include(product => product.OrderItem).SingleOrDefault(a => a.ProductId == key);
                return item;
            }
        }

        public Product Remove(string key)
        {
            Product item;
            item = db.Product.Single(a => a.ProductId == key);
            db.Product.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(Product item)
        {
            db.Product.Update(item);
            db.SaveChanges();
        }
    }
}