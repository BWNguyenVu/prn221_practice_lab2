using BusinessObject;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private readonly UserManager<Account> _userManager;

        public AccountDAO(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Account> GetAccountByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<Account> GetAccountByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityResult> CreateAccountAsync(Account account, string password)
        {
            return await _userManager.CreateAsync(account, password);
        }
    }
}
