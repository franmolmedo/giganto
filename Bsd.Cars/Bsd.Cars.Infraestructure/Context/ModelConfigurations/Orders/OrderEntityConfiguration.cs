using Bsd.Cars.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bsd.Cars.Infraestructure.Context.ModelConfigurations.Orders
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Id)
                .ForSqlServerUseSequenceHiLo($"{nameof(Order)}");

            builder.Property(o => o.CarFrame)
                .HasMaxLength(Order.CarFrameMaxLengh)
                .IsRequired();

            builder.Property(o => o.Model)
                .HasMaxLength(Order.ModelMaxLengh)
                .IsRequired();

            builder.Property(o => o.LicensePlate)
                .HasMaxLength(Order.LicensePlateMaxLengh)
                .IsRequired();

            builder.Property(o => o.DeliveryDate)
                .IsRequired();
        }
    }
}
