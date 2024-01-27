using Contracts;
using Spectre.Console;

namespace Console.Scenarios.Login;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _service;

    public AdminLoginScenario(IAdminService userService)
    {
        _service = userService;
    }

    public string Name => "Admins login";

    public async Task Run()
    {
        int password = AnsiConsole.Ask<int>("Enter password");
        LoginResult result = await _service.Login(password);
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