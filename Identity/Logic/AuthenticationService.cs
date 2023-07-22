using Identity.Model;
using Microsoft.AspNetCore.Identity;
using System.Transactions;

namespace Identity.Logic
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> _userManager;
        public AuthenticationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> CreateUser(UserDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null) return false;

            user = new AppUser()
            {
                Email = request.Email,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                PhoneNumber = request.PhoneNumber,
                UserName =  request.Email
            };
            TransactionManager.ImplicitDistributedTransactions = true;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var createUser = await _userManager.CreateAsync(user, request.Password);
                if (createUser.Succeeded)
                {
                    transaction.Complete();
                    return true;
                }
                   
            }

            return false;

        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var checkUser = await _userManager.CheckPasswordAsync(user, password);

            return checkUser;        }
    }
}
