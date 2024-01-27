using Contracts;
using Spectre.Console;

namespace Console.Scenarios.UserActions;

public class WithdrawalScenario : IScenario
{
    private readonly IUserService _service;

    public WithdrawalScenario(IUserService service)
    {
        _service = service;
    }

    public string Name => "Withdrawal";

    public async Task Run()
    {
        int pin = AnsiConsole.Ask<int>("How many?");
        WithdrawalResult result = await _service.Withdrawal(pin);
        string message = result switch
        {
            WithdrawalResult.Fault => "Not enough money",
            WithdrawalResult.Success => "Success",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };
        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("Press anything to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}