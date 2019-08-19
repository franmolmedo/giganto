using Bsd.Cars.Application.Orders.Responses;
using Bsd.Cars.Domain.Orders;
using Bsd.Cars.Domain.Repositories.Orders;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bsd.Cars.Application.Orders
{
    public sealed class CreateOrderRequest : IRequest<OrderModel>
    {        
        public string CarFrame { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }

    public sealed class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {        
        public CreateOrderValidator()
        {    
            RuleFor(o => o.CarFrame).NotEmpty().MaximumLength(Order.CarFrameMaxLengh);
            RuleFor(o => o.Model).NotEmpty().MaximumLength(Order.ModelMaxLengh);
            RuleFor(o => o.LicensePlate).NotEmpty().MaximumLength(Order.LicensePlateMaxLengh);
        }
    }

    public sealed class CreateOrderHandler : IRequestHandler<CreateOrderRequest, OrderModel>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderModel> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = Order.Create(request.CarFrame,
                                     request.Model,
                                     request.LicensePlate);
            await _orderRepository.Add(order, cancellationToken);
            return new OrderModel
            {
                Id = order.Id,
                CarFrame = order.CarFrame,
                Model = order.Model,
                LicensePlate = order.LicensePlate,
                DeliveryDate = order.DeliveryDate
            };
        }
    }
}
