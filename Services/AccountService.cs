using BusinessObject;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static AccountRepository;
using DAO;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<Account> _signInManager;

        public AccountService(IAccountRepository accountRepository, SignInManager<Account> signInManager)
        {
            _accountRepository = accountRepository;
            _signInManager = signInManager;
        }

        
        public async Task<Account> RegisterAsync(string username, string password, string name)
        {
            var account = new Account { UserName = username, Id = Guid.NewGuid().ToString(), Name =  name};
            return await _accountRepository.CreateAccountAsync(account, password);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _accountRepository.GetUserProfileByUsernameAsync(username);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim("UserName", user.UserName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await _signInManager.Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return true;
            }

            return false;
        }

        public async Task<UserProfileViewModel> GetUserProfileAsync(string userId)
        {
            var account = await _accountRepository.GetUserProfileAsync(userId);
            if (account == null) return null;

            return new UserProfileViewModel
            {
                Name = account.Name,
                UserName = account.UserName
            };
        }

        public async Task<UserProfileViewModel> GetUserProfileByUsernameAsync(string username)
        {
            var account = await _accountRepository.GetUserProfileByUsernameAsync(username);
            if (account == null) return null;

            return new UserProfileViewModel
            {
                Name = account.Name,
                UserName = account.UserName
            };
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
