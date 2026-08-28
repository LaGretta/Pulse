using Microsoft.Extensions.DependencyInjection;
using Pulse.Application.Interfaces.Service;
using Pulse.Application.Service;

namespace Pulse.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService,AuthService>();
        
        return services;
    }
}