using Shopping_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Store.Repo
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
    }
}
