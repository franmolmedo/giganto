using Bsd.Cars.Application.Orders.Queries;
using Bsd.Cars.Application.Orders.Responses;
using Bsd.Cars.Infraestructure.Context;
using Bsd.Cars.Infraestructure.Queries.Shared;
using Dapper;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Bsd.Cars.Infraestructure.Queries.Orders
{
    public class GetOrderById : DapperQueryBase, IQuery, IGetOrderById
    {
        public GetOrderById(SqlConnection sqlConnection) : base(sqlConnection)
        { }

        public async Task<OrderModel> Query(int id, CancellationToken cancellationToken)
        {
            var select = $@"
            SELECT 
            {nameof(OrderModel.Id)},
            {nameof(OrderModel.CarFrame)},
            {nameof(OrderModel.Model)},
            {nameof(OrderModel.LicensePlate)},
            {nameof(OrderModel.DeliveryDate)}
            FROM {nameof(CarsContext.Orders)} WHERE
            {nameof(OrderModel.Id)} = @{nameof(id)}";

            var orderResult = await WithConnection(async connection =>
            {
                return await connection.QueryFirstOrDefaultAsync<OrderModel>(select, new { id });
            }, cancellationToken);

            return orderResult;
        }
    }
}
