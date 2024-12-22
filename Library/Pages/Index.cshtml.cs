using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

namespace Library.Pages;

public class IndexModel : PageModel
{
    private readonly DataContext _context;

    public IndexModel(DataContext context)
    {
        _context = context;
    }


    public List<TeaDetail> TeaDetails { get; set; }

    public async Task OnGetAsync()
    {
        // Fetch all tea details from the database
        TeaDetails = await _context.TeaDetails.ToListAsync();
    }

    [BindProperty]
    public TeaDetail NewTea { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            _context.TeaDetails.Add(NewTea);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Success");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error saving tea: {ex.Message}");
            return Page();
        }
    }
}

