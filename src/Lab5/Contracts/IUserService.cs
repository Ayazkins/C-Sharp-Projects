namespace Contracts;

public interface IUserService
{
    Task<LoginResult> Login(int id, int pin);

    Task Replenishment(int value);

    Task<WithdrawalResult> Withdrawal(int value);

    Task SignIn(int pin);

    Task<int> CheckBalance();
}