using System.Globalization;
using Contracts;
using Spectre.Console;

namespace Console.Scenarios.UserActions;

public class CheckBalanceScenario : IScenario
{
    private readonly IUserService _service;

    public CheckBalanceScenario(IUserService service)
    {
        _service = service;
    }

    public string Name => "Check balance";

    public async Task Run()
    {
        int result = await _service.CheckBalance();
        AnsiConsole.WriteLine("Balance: " + result.ToString(CultureInfo.InvariantCulture));
        AnsiConsole.WriteLine("Press anything to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}