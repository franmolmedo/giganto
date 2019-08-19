using Bsd.Cars.Domain.Shared;
using Bsd.Cars.Domain.Validations;
using System;

namespace Bsd.Cars.Domain.Orders
{
    public class Order : IEntity
    {
        public const int CarFrameMaxLengh = 30;
        public const int ModelMaxLengh = 30;
        public const int LicensePlateMaxLengh = 8;


        public int Id { get;private set; }
        public string CarFrame { get; private set; }
        public string Model { get; private set; }
        public string LicensePlate { get; private set; }
        public DateTime DeliveryDate { get; private set; }

        private Order()
        { }

        public static Order Create(
                       string carFrame,
                       string model,
                       string licensePlate)
        {
            ValidateCarFrame(carFrame);
            ValidateModel(model);
            ValidateLicensePlate(licensePlate);

            var order = new Order
            {
                CarFrame = carFrame,
                Model = model,
                LicensePlate = licensePlate,
                DeliveryDate = DateTime.UtcNow
            };

            return order;
        }

        public static Order Delete(int id)
        {
            var order = new Order
            {
                Id = id
            };
            return order;
        }

        public void Update(
                string carFrame,
                string model,
                string licensePlate
            )
        {
            ValidateCarFrame(carFrame);
            ValidateModel(model);
            ValidateLicensePlate(licensePlate);

            CarFrame = carFrame;
            Model = model;
            LicensePlate = licensePlate;
            DeliveryDate = DateTime.UtcNow;
        }
                
        private static void ValidateCarFrame(string carFrame)
        {
            DomainPreconditions.NotNull(carFrame, nameof(CarFrame));
            DomainPreconditions.NotEmpty(carFrame, nameof(CarFrame));
            DomainPreconditions.LongerThan(carFrame, CarFrameMaxLengh, nameof(CarFrame));
        }

        private static void ValidateModel(string model)
        {
            DomainPreconditions.NotNull(model, nameof(Model));
            DomainPreconditions.NotEmpty(model, nameof(Model));
            DomainPreconditions.LongerThan(model, ModelMaxLengh, nameof(Model));
        }

        private static void ValidateLicensePlate(string licensePlate)
        {
            DomainPreconditions.NotNull(licensePlate, nameof(LicensePlate));
            DomainPreconditions.NotEmpty(licensePlate, nameof(LicensePlate));
            DomainPreconditions.LongerThan(licensePlate, LicensePlateMaxLengh, nameof(LicensePlate));
        }
    }
}
