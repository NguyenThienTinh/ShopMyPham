using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace ShopMyPham.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ShopMyPhamDbContext context;
        public EFOrderRepository(ShopMyPhamDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Book);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Book));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}