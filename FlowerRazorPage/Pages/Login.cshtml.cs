using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using static AccountRepository;

public class LoginModel : PageModel
{
    private readonly IAccountService _accountService;

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public LoginModel(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public UserProfileViewModel UserProfile { get; set; }
    public async void OnGet()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            return;
        }
        UserProfile =  await _accountService.GetUserProfileAsync(userId);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            if (await _accountService.LoginAsync(Username, Password))
            {
                return RedirectToPage("/Index"); // Redirect to Index page after successful login
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt."); // This error will be displayed in the validation summary
        }
        return Page();
    }
}
