using Abstractions;
using Application.Exceptions;
using Contracts;
using Models.Users;

namespace Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ICurrentUserService _currentUserManager;

    public UserService(IUserRepository repository, ICurrentUserService currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public async Task<LoginResult> Login(int id, int pin)
    {
        User? user = await _repository.GetUser(id, pin);
        if (user is null)
        {
            return new LoginResult.Fault();
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public async Task Replenishment(int value)
    {
        if (_currentUserManager.User == null)
            throw new NoUserException();
        await _repository.Replenishment(_currentUserManager.User.Id, value);
    }

    public async Task<WithdrawalResult> Withdrawal(int value)
    {
        if (_currentUserManager.User == null)
        {
            throw new NoUserException();
        }

        return await _repository.TryWithdrawal(_currentUserManager.User.Id, value);
    }

    public async Task SignIn(int pin)
    {
       _currentUserManager.User = await _repository.CreateUser(pin);
    }

    public async Task<int> CheckBalance()
    {
        if (_currentUserManager.User == null)
        {
            throw new NoUserException();
        }

        return await _repository.GetBalance(_currentUserManager.User.Id);
    }
}