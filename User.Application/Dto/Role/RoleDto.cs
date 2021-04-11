using System;

namespace User.Application.Dto.Role
{
    public sealed class RoleDto
    {
        public RoleDto(Guid id,
            string name) =>
                (Id, Name) = (id, Name);
        
        public Guid Id { get; }
        public string Name { get; }
    }
}
