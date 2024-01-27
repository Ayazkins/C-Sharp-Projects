using Models.Transactions;

namespace Contracts;

public interface IAdminService
{
    Task<LoginResult> Login(int password);

    Task<IList<Transaction>> CheckTransaction();
}