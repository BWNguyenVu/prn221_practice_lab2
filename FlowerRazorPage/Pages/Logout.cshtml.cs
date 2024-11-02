using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowerRazorPage.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LogoutModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGet()
        {
            await _accountService.LogoutAsync();
            return RedirectToPage("/Index"); // Redirect to the home page after logout
        }
    }
}
