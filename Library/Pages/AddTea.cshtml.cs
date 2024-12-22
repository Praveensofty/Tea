using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApi.Helpers;

namespace Library.Pages
{
	public class AddTeaModel : PageModel
    {
        private readonly DataContext _context;

        public AddTeaModel(DataContext context)
        {
            _context = context;
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
                ModelState.AddModelError("", $"Error saving book: {ex.Message}");
                return Page();
            }
        }
    }
}
