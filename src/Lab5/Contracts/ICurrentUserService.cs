using Models.Users;

namespace Contracts;

public interface ICurrentUserService
{
    Admin? Admin { get; set; }
    User? User { get; set; }
    bool IsFree();
}