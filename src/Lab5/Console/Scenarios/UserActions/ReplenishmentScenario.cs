using Contracts;
using Spectre.Console;

namespace Console.Scenarios.UserActions;

public class ReplenishmentScenario : IScenario
{
    private readonly IUserService _service;

    public ReplenishmentScenario(IUserService service)
    {
        _service = service;
    }

    public string Name => "Replenishment";

    public async Task Run()
    {
        int value = AnsiConsole.Ask<int>("How many?");
        await _service.Replenishment(value);
        AnsiConsole.WriteLine("Finished");
        AnsiConsole.WriteLine("Press anything to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}