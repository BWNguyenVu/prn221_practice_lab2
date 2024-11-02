using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services;
using static AccountRepository;
using System.Security.Claims;

namespace FlowerRazorPage.Pages
{
    public class ManageModel : PageModel
    {
        private readonly IFlowerService _flowerService;
        private readonly IAccountService _accountService;
        private readonly ILogger<IndexModel> _logger;

        public ManageModel(IFlowerService flowerService, IAccountService accountService, ILogger<IndexModel> logger)
        {
            _flowerService = flowerService;
            _accountService = accountService;
            _logger = logger;
        }

        public IList<Flower> Flowers { get; set; }
        public UserProfileViewModel UserProfile { get; set; }
        public string SearchTerm { get; set; }

        public async Task OnGetAsync(string searchTerm)
        {
            SearchTerm = searchTerm;

            // Retrieve userId from the NameIdentifier claim
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // Log the retrieved userId or if it's null
            if (userId == null)
            {
                _logger.LogWarning("User is not authenticated. Cannot retrieve userId.");
                // You can redirect to a login page or return an error message, depending on your requirement
                return;
            }

            _logger.LogInformation("Retrieved userId: {UserId}", userId);

            // Fetch user profile and flowers only if userId is valid
            UserProfile = await _accountService.GetUserProfileAsync(userId);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                Flowers = await _flowerService.SearchFlowersByNameAndByUserIdAsync(searchTerm, userId);
            }
            else
            {
                Flowers = await _flowerService.GetAllFlowersByUserIdAsync(userId);
            }
        }
    }
}
