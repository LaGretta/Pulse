using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pulse.Application.Interfaces.Repository;
using Pulse.Application.Interfaces.Security;
using Pulse.Infrastructure.Data;
using Pulse.Infrastructure.Repository;
using Pulse.Infrastructure.Security;

namespace Pulse.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PulseDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}