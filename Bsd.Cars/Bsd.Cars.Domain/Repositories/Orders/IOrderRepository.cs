using Bsd.Cars.Domain.Orders;
using Bsd.Cars.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Bsd.Cars.Domain.Repositories.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> FindById(int id, CancellationToken cancellationToken);
        void Delete(Order order, CancellationToken cancellationToken);
    }
}
