using BusinessObject;
using DAO;
using Microsoft.AspNetCore.Identity;
using Repositories;
using System.Threading.Tasks;

public class AccountRepository : IAccountRepository
{
    private readonly AccountDAO _accountDAO;

    public class UserProfileViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
    }

    public AccountRepository(AccountDAO accountDAO)
    {
        _accountDAO = accountDAO;
    }

    public async Task<Account> GetAccountByUsernameAsync(string username)
    {
        return await _accountDAO.GetAccountByUsernameAsync(username);
    }

    public async Task<Account> CreateAccountAsync(Account account, string password)
    {
        var result = await _accountDAO.CreateAccountAsync(account, password);
        return result.Succeeded ? account : null;
    }

    public async Task<UserProfileViewModel> GetUserProfileAsync(string userId)
    {
        var account = await _accountDAO.GetAccountByIdAsync(userId);
        if (account == null) return null;

        return new UserProfileViewModel
        {
            Name = account.Name,
            UserName = account.UserName,
            Id = account.Id
        };
    }

    public async Task<UserProfileViewModel> GetUserProfileByUsernameAsync(string username)
    {
        var account = await _accountDAO.GetAccountByUsernameAsync(username);
        if (account == null) return null;

        return new UserProfileViewModel
        {
            Name = account.Name,
            UserName = account.UserName,
            Id = account.Id
        };
    }
}
