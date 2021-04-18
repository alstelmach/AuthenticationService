using System.Reflection;
using AsCore.Infrastructure.Persistence.BuildingBlocks;
using AsCore.Infrastructure.Persistence.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Repositories;
using User.Infrastructure.Persistence.Read.Context;
using User.Infrastructure.Persistence.Read.Repositories;

namespace User.Infrastructure.Persistence.Read
{
    internal static class ReadModelConfiguration
    {
        private const string UserContextConnectionStringSectionKey = "UserContextRead";

        internal static IServiceCollection AddReadModelDependencies(this IServiceCollection services,
            IConfiguration configuration) =>
                services
                    .AddDatabaseContext<UserReadModelContext>(configuration,
                        DatabaseProvider.PostgreSQL,
                        true,
                        UserContextConnectionStringSectionKey,
                        Assembly.GetExecutingAssembly().FullName)
                    .AddScoped<IRoleDtoRepository, RoleDtoRepository>()
                    .AddScoped<IUserDtoRepository, UserDtoRepository>();

        internal static IApplicationBuilder UseReadModelMiddlewares(this IApplicationBuilder builder) =>
            builder
                .UseMigrationsOfContext<UserReadModelContext>();
    }
}
