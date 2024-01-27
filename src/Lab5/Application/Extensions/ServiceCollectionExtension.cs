using Application.Users;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<CurrentUser>();
        collection.AddScoped<ICurrentUserService>(p => p.GetRequiredService<CurrentUser>());
        return collection;
    }
}