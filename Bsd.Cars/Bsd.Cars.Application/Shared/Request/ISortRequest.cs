using System.Collections.Generic;

namespace Bsd.Cars.Application.Shared.Request
{
    public interface ISortRequest
    {
        List<Sort> Sort { get; set; }
    }
}
