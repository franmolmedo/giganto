using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Bsd.Cars.Application.Shared;
using Bsd.Cars.Application.Orders.Responses;
using Bsd.Cars.Application.Orders.Queries;

namespace Bsd.Cars.Application.Orders
{
    public class GetOrdersRequest : PaginatedRequest, IRequest<PaginatedResponse<OrderModel>>
    { }

    public class GetOrdersHandler : IRequestHandler<GetOrdersRequest, PaginatedResponse<OrderModel>>
    {
        private readonly IGetOrders _query;

        public GetOrdersHandler(IGetOrders query)
        {
            _query = query;
        }

        public async Task<PaginatedResponse<OrderModel>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            return await _query.Query(request);
        }
    }
}
