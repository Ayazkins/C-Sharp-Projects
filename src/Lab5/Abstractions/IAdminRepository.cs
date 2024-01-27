using Contracts;
using Models.Transactions;

namespace Abstractions;

public interface IAdminRepository
{
    Task<LoginResult> CheckPassword(int password);
    Task<IList<Transaction>> GetTransactions();
}