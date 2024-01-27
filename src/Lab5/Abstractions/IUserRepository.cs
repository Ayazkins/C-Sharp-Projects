using Contracts;
using Models.Users;

namespace Abstractions;

public interface IUserRepository
{
    Task<User?> GetUser(int id, int pin);

    Task<User> CreateUser(int pin);

    Task<WithdrawalResult> TryWithdrawal(int id, int value);

    Task Replenishment(int id, int value);

    Task<int> GetBalance(int id);
}