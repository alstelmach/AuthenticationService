using System;
using User.Domain.Permission.Factories;
using User.Domain.Role.Exceptions;
using User.Domain.Role.Factories;
using Xunit;

namespace User.UnitTests.Domain.Role
{
    public static class RoleTests
    {
        [Fact]
        public static void ShouldAssignPermissionToRole()
        {
            // Arrange
            var permissionId = Guid.NewGuid();
            var permission = PermissionFactory.Create(permissionId, string.Empty);
            var role = RoleFactory.Create(Guid.NewGuid(), string.Empty);
            
            // Act
            role.AssignPermission(permission);
            
            // Assert
            Assert.Contains(role.Permissions,
                permission => permission == permissionId);
        }
        
        [Fact]
        public static void ShouldNotDuplicateAssignedPermission()
        {
            // Arrange
            var assignedPermissionId = Guid.NewGuid();
            var assignedPermission = PermissionFactory.Create(assignedPermissionId, string.Empty);
            var role = RoleFactory.Create(Guid.NewGuid(), string.Empty);
            role.AssignPermission(assignedPermission);

            var anotherPermission = PermissionFactory.Create(assignedPermissionId, string.Empty);
            
            // Act
            void AssignPermissionAction() => role.AssignPermission(anotherPermission);
            
            // Assert
            Assert.Throws<PermissionAlreadyAssignedToRoleException>(AssignPermissionAction);
        }
    }
}
