using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Application.Abstractions.Messaging.Queries;
using User.Application.Contracts.User.Queries;
using User.Application.Dto;
using User.Application.Dto.Repositories;

namespace User.Application.Handlers.QueryHandlers
{
    public sealed class UserQueryHandler : IQueryHandler<GetUserQuery, UserDto>,
        IQueryHandler<GetUsersQuery, IEnumerable<UserDto>>,
        IQueryHandler<GetUserRolesQuery, IEnumerable<RoleDto>>
    {
        private readonly IUserDtoRepository _userDtoRepository;
        private readonly IRoleDtoRepository _roleDtoRepository;

        public UserQueryHandler(IUserDtoRepository userDtoRepository,
            IRoleDtoRepository roleDtoRepository)
        {
            _userDtoRepository = userDtoRepository;
            _roleDtoRepository = roleDtoRepository;
        }

        public async Task<UserDto> Handle(GetUserQuery query, CancellationToken cancellationToken) =>
            await _userDtoRepository
                .GetAsync(query.Id, cancellationToken);

        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery query, CancellationToken cancellationToken) =>
            await _userDtoRepository
                .GetAsync(cancellationToken);

        public async Task<IEnumerable<RoleDto>> Handle(GetUserRolesQuery query, CancellationToken cancellationToken) =>
            await _roleDtoRepository
                .GetUserRolesAsync(query.UserId, cancellationToken);
    }
}
