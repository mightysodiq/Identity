using Identity.Model;

namespace Identity.Logic
{
    public interface IAuthenticationService
    {
        Task<bool> CreateUser(UserDto request);
        Task<bool> Login(string email, string password);
    }
}
