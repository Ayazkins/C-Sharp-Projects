using System.Diagnostics.CodeAnalysis;
using Contracts;

namespace Console.Scenarios.UserActions;

public class RegistrationScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public RegistrationScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null || _currentUser.Admin is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new RegistrationScenario(_service);
        return true;
    }
}