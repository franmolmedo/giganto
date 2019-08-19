using System.Threading;
using System.Threading.Tasks;
using Bsd.Cars.Domain.Orders;
using Bsd.Cars.Domain.Repositories.Orders;
using MediatR;

namespace Bsd.Cars.Application.Orders
{
    public class DeleteOrderRequest : IRequest
    {
        public int Id { get; set; }

        public sealed class DeleteOrderHandler : IRequestHandler<DeleteOrderRequest>
        {
            private readonly IOrderRepository _orderRepository;
            public DeleteOrderHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<Unit> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
            {
                var order = Order.Delete(request.Id);

                _orderRepository.Delete(order, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
