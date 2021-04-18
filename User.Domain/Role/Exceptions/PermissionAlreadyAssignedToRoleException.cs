using System;
using AsCore.Domain.Abstractions.BuildingBlocks;

namespace User.Domain.Role.Exceptions
{
    [Serializable]
    public sealed class PermissionAlreadyAssignedToRoleException : DomainException
    {
        private const string MessagePattern = "Permission already assigned to {0} role";

        internal PermissionAlreadyAssignedToRoleException(string roleName)
            : base(string.Format(MessagePattern, roleName))
        {
        }
    }
}
