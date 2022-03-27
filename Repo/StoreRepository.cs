using Shopping_Store.AppContext;
using Shopping_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Store.Repo
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDBContext context;

        public StoreRepository(AppDBContext _context)
        {
            context = _context;
        }

        public IQueryable<Product> Products => context.Products;
    }
}
