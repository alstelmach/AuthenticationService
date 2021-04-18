using System.Security.Claims;
using AsCore.Application.Abstractions.Messaging.Commands;

namespace User.Application.Contracts.User.Commands
{
    public sealed class ChangeUserPasswordCommand : ICommand
    {
        public string Password { get; init; }
        public string NewPassword { get; init; }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
    }
}
