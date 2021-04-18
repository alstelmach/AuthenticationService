using System;

namespace User.Domain.Permission.Factories
{
    public static class PermissionFactory
    {
        public static Permission Create(Guid id,
            string description) =>
                new (id,
                    description);
    }
}
