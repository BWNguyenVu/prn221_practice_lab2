using BusinessObject;
using System.Threading.Tasks;
using static AccountRepository;

public interface IAccountService
{
    Task<Account> RegisterAsync(string username, string password, string name);
    Task<bool> LoginAsync(string username, string password);
    Task<UserProfileViewModel> GetUserProfileAsync(string userId);
    Task LogoutAsync();
}
