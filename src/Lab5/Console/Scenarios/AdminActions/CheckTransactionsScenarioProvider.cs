using System.Diagnostics.CodeAnalysis;
using Contracts;

namespace Console.Scenarios.AdminActions;

public class CheckTransactionsScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentUser;

    public CheckTransactionsScenarioProvider(
        IAdminService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.Admin is null || _currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckTransactionsScenario(_service);
        return true;
    }
}