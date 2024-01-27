using Spectre.Console;

namespace Console.Scenarios;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _providers;

    public ScenarioRunner(IEnumerable<IScenarioProvider> providers)
    {
        _providers = providers;
    }

    public async Task Run()
    {
        IEnumerable<IScenario> scenarios = GetScenarios();

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        await scenario.Run();
    }

    private IEnumerable<IScenario> GetScenarios()
    {
        foreach (IScenarioProvider provider in _providers)
        {
            if (provider.TryGetScenario(out IScenario? scenario))
                yield return scenario;
        }
    }
}