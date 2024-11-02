using BusinessObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Services;
using static AccountRepository;
using System.Security.Claims;

public class DetailsModel : PageModel
{
    private readonly IFlowerService _flowerService;
    private readonly IFlowerMediaService _flowerMediaService;
    private readonly UserManager<Account> _userManager;
    private readonly ILogger<CreateModel> _logger;
    private readonly IAccountService _accountService;

    public DetailsModel(IFlowerService flowerService, IAccountService accountService,
                        IFlowerMediaService flowerMediaService, UserManager<Account> userManager,
                        ILogger<CreateModel> logger)
    {
        _flowerService = flowerService;
        _flowerMediaService = flowerMediaService;
        _userManager = userManager;
        _logger = logger;
        _accountService = accountService;
    }

    public Flower Flower { get; set; }
    public IList<FlowerMedia> FlowerMedia { get; set; }
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
        FlowerMedia = await _flowerMediaService.GetAllMediaByFlowerIdAsync(id);

        if (Flower == null)
        {
            return NotFound();
        }
        return Page();
    }

    public IActionResult OnPostUpdateMediaAsync(string MediaId, string MediaType, string Caption, string FlowerId)
    {
        var media = new FlowerMedia
        {
            Id = MediaId,
            MediaType = MediaType,
            Caption = Caption
        };

         _flowerMediaService.UpdateFlowerMediaAsync(media);
        Flower =  _flowerService.GetFlowerByIdAsync(FlowerId);

        return RedirectToPage("Details", new { id = FlowerId });
    }

}
