using System.Globalization;
using Abstractions;
using Contracts;
using Models.Users;
using Npgsql;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private const string Connection =
        "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=postgres";

    private const string GetUserQuery = """
                                        select id
                                        from users
                                        where id = :id and pin = :pin
                                        """;

    private const string GetUserQueryWithNoPin = """
                                                 select *
                                                 from users
                                                 where id = :id
                                                 """;

    private const string GetLastIdQuery = """
                                          select id
                                          from users
                                          order by id desc
                                          limit 1
                                          """;

    private const string InsertNewUserQuery = """
                                              insert into users values (:id, :pin, :amount);
                                              """;

    private const string UpdateUserValue = """
                                           update users
                                           set amount = amount + :newAmount
                                           where id = :id
                                           """;

    private const string CheckBalance = """
                                        select amount from users where id = :id;
                                        """;

    private const string AddToTransactionsReplenishment = """
                                                          insert into transactions values(:id, 'replenishment', :value);
                                                          """;

    private const string AddToTransactionsWithdrawal = """
                                                       insert into transactions values(:id, 'withdrawal', :value);
                                                       """;

    public async Task<User?> GetUser(int id, int pin)
    {
        using var sqlConnection = new NpgsqlConnection(Connection);
        await sqlConnection.OpenAsync().ConfigureAwait(false);

        using var command = new NpgsqlCommand(GetUserQuery, sqlConnection);
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("pin", pin);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            return new User(
                Convert.ToInt32(reader["id"], CultureInfo.InvariantCulture));
        }

        return null;
    }

    public async Task<User> CreateUser(int pin)
    {
        using var sqlConnection = new NpgsqlConnection(Connection);
        await sqlConnection.OpenAsync().ConfigureAwait(false);

        using var getLastIdCommand = new NpgsqlCommand(GetLastIdQuery, sqlConnection);
        using NpgsqlDataReader reader = await getLastIdCommand.ExecuteReaderAsync().ConfigureAwait(false);

        int id = 1;
        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            id = Convert.ToInt32(reader["id"], CultureInfo.InvariantCulture) + 1;
        }

        await reader.CloseAsync().ConfigureAwait(false);
        using var insertUserCommand = new NpgsqlCommand(InsertNewUserQuery, sqlConnection);
        insertUserCommand.Parameters.AddWithValue("id", id);
        insertUserCommand.Parameters.AddWithValue("pin", pin);
        insertUserCommand.Parameters.AddWithValue("amount", 0);
        await insertUserCommand.ExecuteNonQueryAsync().ConfigureAwait(false);

        return new User(id);
    }

    public async Task<WithdrawalResult> TryWithdrawal(int id, int value)
    {
        using var sqlConnection = new NpgsqlConnection(Connection);
        await sqlConnection.OpenAsync().ConfigureAwait(false);

        using var getUserCommand = new NpgsqlCommand(GetUserQueryWithNoPin, sqlConnection);
        getUserCommand.Parameters.AddWithValue("id", id);
        using NpgsqlDataReader reader = await getUserCommand.ExecuteReaderAsync().ConfigureAwait(false);
        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            int curAmount = Convert.ToInt32(reader["amount"], CultureInfo.InvariantCulture);
            await reader.CloseAsync().ConfigureAwait(false);
            if (curAmount >= value && value > 0)
            {
                using var updateCommand = new NpgsqlCommand(UpdateUserValue, sqlConnection);
                updateCommand.Parameters.AddWithValue("id", id);
                updateCommand.Parameters.AddWithValue("newAmount", -value);
                await updateCommand.ExecuteNonQueryAsync().ConfigureAwait(false);
                using var addToTransactions = new NpgsqlCommand(AddToTransactionsWithdrawal, sqlConnection);
                addToTransactions.Parameters.AddWithValue("id", id);
                addToTransactions.Parameters.AddWithValue("value", value);
                await addToTransactions.ExecuteNonQueryAsync().ConfigureAwait(false);
                return new WithdrawalResult.Success();
            }
        }

        return new WithdrawalResult.Fault();
    }

    public async Task Replenishment(int id, int value)
    {
        if (value < 0)
        {
            return;
        }

        using var sqlConnection = new NpgsqlConnection(Connection);
        await sqlConnection.OpenAsync().ConfigureAwait(false);
        using var updateCommand = new NpgsqlCommand(UpdateUserValue, sqlConnection);
        updateCommand.Parameters.AddWithValue("id", id);
        updateCommand.Parameters.AddWithValue("newAmount", value);
        await updateCommand.ExecuteNonQueryAsync().ConfigureAwait(false);
        using var addToTransactions = new NpgsqlCommand(AddToTransactionsReplenishment, sqlConnection);
        addToTransactions.Parameters.AddWithValue("id", id);
        addToTransactions.Parameters.AddWithValue("value", value);
        await addToTransactions.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<int> GetBalance(int id)
    {
        using var sqlConnection = new NpgsqlConnection(Connection);
        await sqlConnection.OpenAsync().ConfigureAwait(false);

        using var getBalance = new NpgsqlCommand(CheckBalance, sqlConnection);
        getBalance.Parameters.AddWithValue("id", id);
        using NpgsqlDataReader reader = await getBalance.ExecuteReaderAsync().ConfigureAwait(false);
        if (await reader.ReadAsync().ConfigureAwait(false))
        {
            return Convert.ToInt32(reader["amount"], CultureInfo.InvariantCulture);
        }

        return -1;
    }
}