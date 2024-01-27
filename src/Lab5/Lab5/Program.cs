// See https://aka.ms/new-console-template for more information

using Application.Extensions;
using Console.Extensions;
using Console.Scenarios;
using DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Program;

public static class Program
{
    public static async Task Main()
    {
        var collection = new ServiceCollection();
        collection.AddApplication().AddInfrastructureDataAccess().AddPresentationConsole();
        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();
        ScenarioRunner scenarioRunner = scope.ServiceProvider.GetRequiredService<ScenarioRunner>();

        while (true)
        {
            AnsiConsole.Clear();
            await scenarioRunner.Run();
        }
    }
}