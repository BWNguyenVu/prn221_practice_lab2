using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FlowerRazorPage.Migrations;
using Microsoft.AspNetCore.Identity;
using static AccountRepository;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class EditModel : PageModel
{
    private readonly IFlowerService _flowerService;
    private readonly ILogger<EditModel> _logger;
    private readonly IAccountService _accountService;
    public EditModel(IFlowerService flowerService, IAccountService accountService, ILogger<EditModel> logger)
    {
        _flowerService = flowerService;
        _logger = logger;
        _accountService = accountService;
    }

    [BindProperty]
    public Flower Flower { get; set; } = default!;
    [BindProperty]
    public string Name { get; set; }
    public UserProfileViewModel UserProfile { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        UserProfile = await _accountService.GetUserProfileAsync(userId);
        if (userId == null)
        {
            return Page();
        }
        Flower = _flowerService.GetFlowerByIdAsync(id);
        if (Flower == null)
        {
            return NotFound();
        }
        return Page();
    }

    public IActionResult OnPostAsync()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        // Ensure the user is logged in and assign the AccountId
        if (string.IsNullOrEmpty(userId))
        {
            _logger.LogWarning("User ID is null or empty.");
            ModelState.AddModelError("AccountId", "User must be logged in to update the flower.");
            return Page();
        }
        Flower.AccountId = userId;

        {
            // Update the flower
            _flowerService.UpdateFlowerAsync(Flower);

            return RedirectToPage("Index");
        }
    }



}
