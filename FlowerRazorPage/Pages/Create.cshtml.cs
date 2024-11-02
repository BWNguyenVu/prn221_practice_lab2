using BusinessObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Security.Claims;

public class CreateModel : PageModel
{
    private readonly IFlowerService _flowerService;
    private readonly UserManager<Account> _userManager;
    private readonly ILogger<CreateModel> _logger;

    public CreateModel(IFlowerService flowerService, UserManager<Account> userManager, ILogger<CreateModel> logger)
    {
        _flowerService = flowerService;
        _userManager = userManager;
        _logger = logger;
    }

    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public string Category { get; set; }

    [BindProperty]
    public string Description { get; set; }

    [BindProperty]
    public decimal Price { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Log ModelState errors
            foreach (var modelStateEntry in ModelState)
            {
                var key = modelStateEntry.Key;
                var errors = modelStateEntry.Value.Errors;

                foreach (var error in errors)
                {
                    _logger.LogWarning($"ModelState Error - Key: {key}, Error: {error.ErrorMessage}");
                }
            }

            return Page();
        }

        // Get the User ID from claims
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            _logger.LogWarning("User ID is null or empty.");
            ModelState.AddModelError("AccountId", "User must be logged in to create a flower.");
            return Page();
        }

        // Log the userId
        _logger.LogInformation(userId);

        // Create the Flower object
        await _flowerService.CreateFlowerAsync(new Flower
        {
            Category = Category,
            AccountId = userId,
            Name = Name,
            Description = Description,
            Price = Price
        });

        return RedirectToPage("Index");
    }
}
