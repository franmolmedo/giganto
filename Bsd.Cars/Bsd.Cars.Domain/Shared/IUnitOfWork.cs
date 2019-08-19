using System.Threading.Tasks;

namespace Bsd.Cars.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
