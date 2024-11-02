using BusinessObject;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services;
using static AccountRepository;
using System.Security.Claims;
using DTOs;

public class IndexModel : PageModel
{
    private readonly IFlowerService _flowerService;
    private readonly IAccountService _accountService;
    private readonly ILogger<IndexModel> _logger;
    private readonly IFlowerMediaService _flowerMediaService;
    public IndexModel(IFlowerService flowerService, IAccountService accountService, ILogger<IndexModel> logger,
        IFlowerMediaService flowerMediaService)
    {
        _flowerService = flowerService;
        _accountService = accountService;
        _logger = logger;
        _flowerMediaService = flowerMediaService;
    }
    public IList<FlowerMedia> FlowerMedia { get; set; }
    public IList<FlowerResponseDTO> Flowers { get; set; }
    public UserProfileViewModel UserProfile { get; set; }
    public string SearchTerm { get; set; }

    public async Task OnGetAsync(string searchTerm)
    {
        Flowers = await _flowerService.GetAllFlowersAsync();
    }

}
