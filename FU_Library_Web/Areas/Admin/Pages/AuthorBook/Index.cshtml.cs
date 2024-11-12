
using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FU_Library_Web.Areas.Admin.Pages.AuthorBook
{
    public class IndexModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public IndexModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public IList<BookAuthors> BookAuthor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            BookAuthor = await _context.BookAuthors.ToListAsync();
        }
        public async Task<IActionResult> OnPostCreateAsync(string? authorName, string? authorDes)
        {
            var existedName = await _context.BookAuthors.FirstOrDefaultAsync(it => it.FullName.Equals(authorName));
            if (existedName != null)
            {
                return Page();
            }
            else
            {
                BookAuthors newCate = new BookAuthors
                {
                    FullName = authorName,
                    Description = authorDes
                };
                _context.BookAuthors.Add(newCate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var newsItem = await _context.BookAuthors.FindAsync(id);

            if (newsItem == null)
            {
                return NotFound();
            }
            _context.BookAuthors.Remove(newsItem);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
