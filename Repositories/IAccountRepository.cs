using BusinessObject;
using System.Threading.Tasks;
using static AccountRepository;

public interface IAccountRepository
{
    Task<Account> GetAccountByUsernameAsync(string username);
    Task<Account> CreateAccountAsync(Account account, string password);
    Task<UserProfileViewModel> GetUserProfileAsync(string userId);
    Task<UserProfileViewModel> GetUserProfileByUsernameAsync(string username);
}
