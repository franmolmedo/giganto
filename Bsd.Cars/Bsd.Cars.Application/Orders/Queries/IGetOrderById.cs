using Bsd.Cars.Application.Orders.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Bsd.Cars.Application.Orders.Queries
{
    public interface IGetOrderById
    {
        Task<OrderModel> Query(int id, CancellationToken cancellationToken);
    }
}
