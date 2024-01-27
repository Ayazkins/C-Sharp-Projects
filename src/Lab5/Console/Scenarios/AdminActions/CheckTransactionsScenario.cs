using Contracts;
using Spectre.Console;
using Transaction = Models.Transactions.Transaction;

namespace Console.Scenarios.AdminActions;

public class CheckTransactionsScenario : IScenario
{
    private readonly IAdminService _service;

    public CheckTransactionsScenario(IAdminService userService)
    {
        _service = userService;
    }

    public string Name => "Check transactions";

    public async Task Run()
    {
        IList<Transaction> transactions = await _service.CheckTransaction();
        if (transactions.Count == 0)
        {
            AnsiConsole.Ask<int>("Write anything to go");
            AnsiConsole.WriteLine("No transactions yet");
            return;
        }

        foreach (Transaction transaction in transactions)
        {
            AnsiConsole.WriteLine(transaction.ToString());
        }

        AnsiConsole.WriteLine("Press anything to continue");
        AnsiConsole.Console.Input.ReadKey(false);
    }
}