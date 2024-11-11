using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FU_Library_Web;
using FU_Library_Web.Models;

namespace FU_Library_Web.Pages.Authobook
{
    public class DeleteModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public DeleteModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookAuthor BookAuthor { get; set; } = default!;

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
            else
            {
                BookAuthor = bookauthor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookauthor = await _context.BookAuthors.FindAsync(id);
            if (bookauthor != null)
            {
                BookAuthor = bookauthor;
                _context.BookAuthors.Remove(BookAuthor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
