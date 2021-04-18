using System.Security.Claims;
using AsCore.Application.Abstractions.Messaging.Commands;

namespace User.Application.Contracts.User.Commands
{
    public class DeleteUserCommand : ICommand
    {
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
