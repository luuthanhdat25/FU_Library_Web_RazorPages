using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FU_Library_Web.Areas.Admin.Pages.AuthorBook
{
    public class EditModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public EditModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookAuthors BookAuthor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookauthor = await _context.BookAuthors.FirstOrDefaultAsync(m => m.BookAuthorId == id);
            if (bookauthor == null)
            {
                return NotFound();
            }
            BookAuthor = bookauthor;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool nameExists = await _context.BookAuthors
                .AnyAsync(b => b.FullName == BookAuthor.FullName && b.BookAuthorId != BookAuthor.BookAuthorId);

            if (nameExists)
            {
                ModelState.AddModelError("BookAuthor.FullName", "Tên tác giả đã tồn tại.");
                return Page();
            }

            _context.Attach(BookAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAuthorExists(BookAuthor.BookAuthorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }


        private bool BookAuthorExists(Guid id)
        {
            return _context.BookAuthors.Any(e => e.BookAuthorId == id);
        }
    }
}
