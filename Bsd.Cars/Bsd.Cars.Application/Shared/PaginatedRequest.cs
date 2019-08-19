using Bsd.Cars.Application.Shared.Request;
using System.Collections.Generic;

namespace Bsd.Cars.Application.Shared
{
    public class PaginatedRequest : IFilterRequest, IPaginatedRequest, ISortRequest
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public List<Sort> Sort { get; set; } = new List<Sort>();
        public Filter Filter { get; set; } = new Filter();
    }
}
