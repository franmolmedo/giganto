namespace Bsd.Cars.Application.Shared.Request
{
    public interface IPaginatedRequest
    {
        int Skip { get; set; }
        int Take { get; set; }
    }
}
