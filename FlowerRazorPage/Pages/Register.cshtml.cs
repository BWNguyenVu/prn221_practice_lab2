using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using static AccountRepository;

public class RegisterModel : PageModel
{
    private readonly IAccountService _accountService;

    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public RegisterModel(IAccountService accountService)
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
        UserProfile = await _accountService.GetUserProfileAsync(userId);
    }

        public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var account = await _accountService.RegisterAsync(Username, Password, Name);
            if (account != null)
            {
                return RedirectToPage("/Login"); // Redirect to Login page after successful registration
            }
            ModelState.AddModelError(string.Empty, "Registration failed.");
        }
        return Page();
    }
}
