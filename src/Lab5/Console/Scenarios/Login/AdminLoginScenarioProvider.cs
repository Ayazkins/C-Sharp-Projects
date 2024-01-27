using System.Diagnostics.CodeAnalysis;
using Contracts;

namespace Console.Scenarios.Login;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentUser;

    public AdminLoginScenarioProvider(
        IAdminService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.Admin is not null || _currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_service);
        return true;
    }
}