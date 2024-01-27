using System.Diagnostics.CodeAnalysis;
using Contracts;

namespace Console.Scenarios.UserActions;

public class ReplenishmentScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public ReplenishmentScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new ReplenishmentScenario(_service);
        return true;
    }
}