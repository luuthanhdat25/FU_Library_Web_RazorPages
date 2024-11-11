using FU_Library_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FU_Library_Web.Areas.Admin.Pages.New
{
    public class CreateModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public CreateModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public News News { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            News.PublishDate = DateTime.Now;
            _context.News.Add(News);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
