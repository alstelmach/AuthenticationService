using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Abstractions.BuildingBlocks;

namespace User.Domain.User.Repositories
{
    public interface IUserRepository : ICrudRepository<User>
    {
        Task<bool> CheckIsLoginFreeAsync(string login, CancellationToken cancellationToken = default);
        Task<bool> CheckIsMailAddressFreeAsync(string mailAddress, CancellationToken cancellationToken = default);
    }
}
