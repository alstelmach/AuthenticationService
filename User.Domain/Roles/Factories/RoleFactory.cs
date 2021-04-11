using System;

namespace User.Domain.Roles.Factories
{
    public static class RoleFactory
    {
        public static Role Create(Guid id,
            string name) =>
                new (id,
                    name);
    }
}
