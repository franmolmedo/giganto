using Bsd.Cars.Application.Shared;
using Bsd.Cars.Application.Orders.Responses;
using System.Threading.Tasks;

namespace Bsd.Cars.Application.Orders.Queries
{
    public interface IGetOrders
    {
        Task<PaginatedResponse<OrderModel>> Query(GetOrdersRequest request);
    }
}
