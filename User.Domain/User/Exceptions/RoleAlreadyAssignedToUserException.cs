using System;
using AsCore.Domain.Abstractions.BuildingBlocks;

namespace User.Domain.User.Exceptions
{
    [Serializable]
    public sealed class RoleAlreadyAssignedToUserException : DomainException
    {
        private const string MessagePattern = "Role {0} already assigned to {1} user";
        
        public RoleAlreadyAssignedToUserException(string roleName,
            string userLogin)
                : base(string.Format(MessagePattern, roleName, userLogin))
        {
        }
    }
}
