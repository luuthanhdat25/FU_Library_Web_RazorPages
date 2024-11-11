using FU_Library_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FU_Library_Web.Areas.Admin.Pages.New
{
    public class DetailsModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public DetailsModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public News News { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }
            else
            {
                News = news;
            }
            return Page();
        }
    }
}
