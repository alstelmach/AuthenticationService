using System;

namespace User.Infrastructure.Persistence.Read.Entities
{
    public sealed class RolePermissionAssignment
    {
        internal RolePermissionAssignment(Guid roleId,
            Guid permissionId) =>
                (RoleId, PermissionId) = (roleId, permissionId);

        private RolePermissionAssignment()
        {
        }
        
        public Guid RoleId { get; }
        public Guid PermissionId { get; }
    }
}
