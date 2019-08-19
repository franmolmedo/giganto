using Bsd.Cars.Domain.Orders;
using Bsd.Cars.Domain.Repositories.Orders;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bsd.Cars.Application.Orders
{
    public class UpdateOrderRequest : IRequest
    {
        public int Id { get; set; }
        public string CarFrame { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }

    public sealed class UpdateOrderValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderValidator()
        {
            RuleFor(o => o.Model).NotEmpty().MaximumLength(Order.ModelMaxLengh);
            RuleFor(o => o.CarFrame).NotEmpty().MaximumLength(Order.CarFrameMaxLengh);
            RuleFor(o => o.LicensePlate).NotEmpty().MaximumLength(Order.LicensePlateMaxLengh);
        }
    }

    public sealed class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest>
    {
        private readonly IOrderRepository _orderRepository;
        public UpdateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindById(request.Id, cancellationToken);

            order.Update(request.CarFrame, request.Model, request.LicensePlate);

            return Unit.Value;
        }
    }
}
