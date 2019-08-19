using System;

namespace Bsd.Cars.Application.Orders.Responses
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string CarFrame { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
