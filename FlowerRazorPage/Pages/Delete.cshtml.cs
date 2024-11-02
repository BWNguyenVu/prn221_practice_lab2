using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject;
using Services;
using System.Threading.Tasks;

public class DeleteModel : PageModel
{
    private readonly IFlowerService _flowerService;

    public DeleteModel(IFlowerService flowerService)
    {
        _flowerService = flowerService;
    }

    [BindProperty]
    public Flower Flower { get; set; }

    public IActionResult OnGet(string id)
    {
        Flower = _flowerService.GetFlowerByIdAsync(id);
        if (Flower == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _flowerService.DeleteFlowerAsync(Flower.Id);
        return RedirectToPage("Index");
    }
}
