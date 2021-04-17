using System;
using System.Security.Claims;
using AsCore.Application.Abstractions.Messaging.Commands;

namespace User.Application.Contracts.User.Commands
{
    public sealed class AssignRoleToUserCommand : ICommand
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; init; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
