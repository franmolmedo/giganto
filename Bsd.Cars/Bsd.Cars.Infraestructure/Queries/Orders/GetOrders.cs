using Bsd.Cars.Application.Orders;
using Bsd.Cars.Application.Orders.Queries;
using Bsd.Cars.Application.Orders.Responses;
using Bsd.Cars.Application.Shared;
using Bsd.Cars.Domain.Orders;
using Bsd.Cars.Infraestructure.Context;
using Bsd.Cars.Infraestructure.Extensions;
using Bsd.Cars.Infraestructure.Queries.Shared;
using Bsd.Cars.Infraestructure.Shared.Queries;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace Bsd.Cars.Infraestructure.Queries.Orders
{
    public class GetOrders : IQuery, IGetOrders
    {
        private readonly IDbConnection _db;
        private readonly Dictionary<string, string> _columns = new Dictionary<string, string>
        {
            { "id", $@"{nameof(OrderModel.Id)}" },
            { "carFrame", $@"{nameof(OrderModel.CarFrame)}" },
            { "model", $@"{nameof(OrderModel.Model)}" },
            { "licensePlate", $@"{nameof(OrderModel.LicensePlate)}" },
            { "deliveryDate", $@"{nameof(OrderModel.DeliveryDate)}" }
        };
        public GetOrders(IDbConnection db)
        {
            _db = db;
        }

        public async Task<PaginatedResponse<OrderModel>> Query(GetOrdersRequest request)
        {
            var parameters = new Dictionary<string, object>();
            var where = new SqlWhereBuilder(request, _columns).Build();
            var orderBy = new SqlOrderByBuilder($@"{nameof(OrderModel.Id)} ASC", _columns, request).Build();
            var pagination = new SqlPaginationBuilder(request).Build();

            var select = $@"
                SELECT DISTINCT
                {nameof(OrderModel.Id)},
                {nameof(OrderModel.CarFrame)},
                {nameof(OrderModel.Model)},
                {nameof(OrderModel.LicensePlate)},
                {nameof(OrderModel.DeliveryDate)}
                FROM {nameof(CarsContext.Orders)} {where.Sql} {orderBy} {pagination.Sql}";

            var count = $@"SELECT COUNT(*) FROM {nameof(CarsContext.Orders)} O {where.Sql}";

            parameters.AddRange(where.Parameters);
            parameters.AddRange(pagination.Parameters);

            var result = await _db.QueryMultipleAsync($"{select};{count}", parameters);

            return new PaginatedResponse<OrderModel>(result.Read<OrderModel>(), result.ReadFirst<long>());
        }
    }
}
