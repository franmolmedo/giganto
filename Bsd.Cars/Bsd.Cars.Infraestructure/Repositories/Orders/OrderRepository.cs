using System.Threading;
using System.Threading.Tasks;
using Bsd.Cars.Domain.Orders;
using Bsd.Cars.Domain.Repositories.Orders;
using Bsd.Cars.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Bsd.Cars.Infraestructure.Shared;

namespace Bsd.Cars.Infraestructure.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(CarsContext context) : base(context)
        { }

        public async Task<Order> FindById(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<Order>()
                .SingleOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public void Delete(Order order, CancellationToken cancellationToken)
        {
            if (_context.Orders.SingleOrDefaultAsync(o => o.Id == order.Id) != null)
            {
                _context.Orders.Attach(order);
                _context.Orders.Remove(order);
                _context.SaveChangesAsync();
            }
        }
    }
}
