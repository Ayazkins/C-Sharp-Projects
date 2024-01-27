using Contracts;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class UserLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public UserLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "User login";

    public async Task Run()
    {
        int id = AnsiConsole.Ask<int>("Enter your id");
        int pin = AnsiConsole.Ask<int>("Enter your pin");
        LoginResult result = await _userService.Login(id, pin);
        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.Fault => "Wrong information",
            _ => throw new ArgumentOutOfRangeException(nameof(LoginResult)),
        };
        AnsiConsole.WriteLine(message);
        AnsiConsole.WriteLine("Press anything to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}