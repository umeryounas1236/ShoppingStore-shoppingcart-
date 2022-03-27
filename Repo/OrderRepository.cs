using Microsoft.EntityFrameworkCore;
using Shopping_Store.AppContext;
using Shopping_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Store.Repo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext context;
        public OrderRepository(AppDBContext _context)
        {
            context = _context;
        }
        public IQueryable<Order> Orders => context.Orders
                    .Include(o => o.Lines)
                    .ThenInclude(l => l.Product);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
