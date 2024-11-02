using BusinessObject;
using FlowerRazorPage.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using static AccountRepository;

public class CreateFlowerMediaModel : PageModel
{
    private readonly IFlowerMediaService _flowerMediaService;
    private readonly ILogger<CreateFlowerMediaModel> _logger;
    private readonly IFlowerService _flowerService;
    [BindProperty]
    public string SelectedFlowerId { get; set; }

    public List<Flower> Flowers { get; set; } = new List<Flower>();

    [BindProperty]
    public string MediaType { get; set; }

    [BindProperty]
    public string Caption { get; set; }

    [BindProperty]
    public IFormFile ImageUrl { get; set; } // File upload property

    public CreateFlowerMediaModel(IFlowerMediaService flowerMediaService, IFlowerService flowerService, ILogger<CreateFlowerMediaModel> logger)
    {
        _flowerMediaService = flowerMediaService;
        _logger = logger;
        _flowerService = flowerService;
    }
    public async Task OnGetAsync()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            _logger.LogWarning("User is not authenticated. Cannot retrieve userId.");
            return;
        }

        Flowers = await _flowerService.GetAllFlowersByUserIdAsync(userId);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || ImageUrl == null)
        {
            return Page();
        }

        // Save the uploaded image to a specific location
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", ImageUrl.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await ImageUrl.CopyToAsync(stream);
        }

        // Create FlowerMedia object
        var flowerMedia = new FlowerMedia
        {
            ImageUrl = $"/images/{ImageUrl.FileName}", // Store relative path
            MediaType = MediaType,
            Caption = Caption,
            FlowerId = SelectedFlowerId // Use the selected flower ID
        };

        // Call service to add the flower media
        await _flowerMediaService.AddFlowerMediaAsync(flowerMedia);
        _logger.LogInformation("Flower media created successfully.");

        return RedirectToPage("Index");
    }
}
