using Abstractions;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructureDataAccess(this IServiceCollection collection)
    {
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IAdminRepository, AdminRepository>();
        return collection;
    }
}