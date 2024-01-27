using Console.Scenarios;
using Console.Scenarios.AdminActions;
using Console.Scenarios.Login;
using Console.Scenarios.UserActions;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, UserLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegistrationScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ReplenishmentScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawalScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckTransactionsScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        return collection;
    }
}