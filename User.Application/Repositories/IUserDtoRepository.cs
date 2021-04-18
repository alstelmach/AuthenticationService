using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AsCore.Application.Abstractions.Repositories;
using User.Application.Dto;

namespace User.Application.Repositories
{
    public interface IUserDtoRepository : IReadModelRepository<UserDto>
    {
        Task<IEnumerable<UserDto>> GetAsync(CancellationToken cancellationToken = default);
        Task<UserDto> GetAsync(string login, CancellationToken cancellationToken = default);
        Task<UserDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> CheckIsAuthorized(Guid userId, Guid permissionId, CancellationToken cancellationToken = default);
        Task<UserDto> GetUserIncludingRolesAsync(Guid userId);
    }
}
