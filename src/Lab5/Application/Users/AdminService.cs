using Abstractions;
using Contracts;
using Models.Transactions;
using Models.Users;

namespace Application.Users;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly ICurrentUserService _currentUser;

    public AdminService(ICurrentUserService currentUser, IAdminRepository repository)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public async Task<LoginResult> Login(int password)
    {
        LoginResult isGood = await _repository.CheckPassword(password);
        if (isGood is LoginResult.Success)
        {
            _currentUser.Admin = new Admin();
        }

        return isGood;
    }

    public async Task<IList<Transaction>> CheckTransaction()
    {
        return await _repository.GetTransactions();
    }
}