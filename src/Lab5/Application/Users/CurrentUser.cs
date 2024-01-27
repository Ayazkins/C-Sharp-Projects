using Contracts;
using Models.Users;

namespace Application.Users;

public class CurrentUser : ICurrentUserService
{
    public Admin? Admin { get; set; }
    public User? User { get; set; }
    public bool IsFree()
    {
        return Admin == null && User == null;
    }
}