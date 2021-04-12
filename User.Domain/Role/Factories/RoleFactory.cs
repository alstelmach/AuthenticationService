using System;

namespace User.Domain.Role.Factories
{
    public static class RoleFactory
    {
        public static Role Create(Guid id,
            string name) =>
                new (id,
                    name);
    }
}
