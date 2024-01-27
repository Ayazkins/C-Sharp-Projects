using System.Globalization;
using Abstractions;
using Contracts;
using Models.Transactions;
using Npgsql;

namespace DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private const string PasswordQuery = """
                                         select password
                                         from admin_password
                                         """;

    private const string GetTransactionsQuery = """
                                                select id, operation, value
                                                from transactions
                                                """;

    private const string Connection =
        "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres";

    public async Task<LoginResult> CheckPassword(int password)
    {
        using var sqlConnection = new NpgsqlConnection(Connection);
        await sqlConnection.OpenAsync().ConfigureAwait(false);

        using var command = new NpgsqlCommand(PasswordQuery, sqlConnection);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            if (Convert.ToInt32(reader["password"], CultureInfo.InvariantCulture) == password)
            {
                return new LoginResult.Success();
            }
        }

        return new LoginResult.Fault();
    }

    public async Task<IList<Transaction>> GetTransactions()
    {
        using var sqlConnection = new NpgsqlConnection(Connection);
        await sqlConnection.OpenAsync().ConfigureAwait(false);

        using var command = new NpgsqlCommand(GetTransactionsQuery, sqlConnection);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        IList<Transaction> transactions = new List<Transaction>();
        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            transactions.Add(new Transaction(
                Convert.ToInt32(reader["id"], CultureInfo.InvariantCulture),
                reader["operation"].ToString() == "replenishment" ? TransactionType.Replenishment : TransactionType.Withdrawal,
                Convert.ToInt32(reader["value"], CultureInfo.InvariantCulture)));
        }

        return transactions;
    }
}