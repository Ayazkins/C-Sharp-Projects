using Contracts;
using Spectre.Console;

namespace Console.Scenarios.UserActions;

public class RegistrationScenario : IScenario
{
    private readonly IUserService _service;

    public RegistrationScenario(IUserService service)
    {
        _service = service;
    }

    public string Name => "Sign up";
    public async Task Run()
    {
        int pin = AnsiConsole.Ask<int>("Create pin");
        await _service.SignIn(pin);
        AnsiConsole.WriteLine("Registration finished");
        AnsiConsole.WriteLine("Press anything to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}