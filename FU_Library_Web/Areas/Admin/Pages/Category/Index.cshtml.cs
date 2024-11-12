using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FU_Library_Web.Areas.Admin.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public IndexModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public IList<BookCategories> BookCategory { get; set; } = default!;

        public async Task OnGetAsync()
        {
            BookCategory = await _context.BookCategories.ToListAsync();
        }
        public async Task<IActionResult> OnPostCreateAsync(string? cateName)
        {
            if (string.IsNullOrWhiteSpace(cateName)) return Page();
            var existedName = await _context.BookCategories.FirstOrDefaultAsync(it => it.Name.Equals(cateName));
            if (existedName != null)
            {
                return Page();
            }
            else
            {
                BookCategories newCate = new BookCategories
                {
                    Name = cateName,
                };
                _context.BookCategories.Add(newCate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }    
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var newsItem = await _context.BookCategories.FindAsync(id);

            if (newsItem == null)
            {
                return NotFound();
            }
            _context.BookCategories.Remove(newsItem);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
