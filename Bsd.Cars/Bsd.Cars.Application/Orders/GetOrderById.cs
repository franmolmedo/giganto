using Bsd.Cars.Application.Orders.Queries;
using Bsd.Cars.Application.Orders.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bsd.Cars.Application.Orders
{
    public class GetOrderByIdRequest : IRequest<OrderModel>
    {
        public int Id { get; set; }
    }

    public sealed class GetOrderHandler : IRequestHandler<GetOrderByIdRequest, OrderModel>
    {
        private readonly IGetOrderById _query;

        public GetOrderHandler(IGetOrderById query)
        {
            _query = query;
        }

        public async Task<OrderModel> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            return await _query.Query(request.Id, cancellationToken);
        }
    }
}
