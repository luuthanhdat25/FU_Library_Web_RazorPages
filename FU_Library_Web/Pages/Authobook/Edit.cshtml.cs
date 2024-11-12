using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FU_Library_Web;
using DataAccess.Entity;

namespace FU_Library_Web.Pages.Authobook
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

            var bookauthor =  await _context.BookAuthors.FirstOrDefaultAsync(m => m.BookAuthorId == id);
            if (bookauthor == null)
            {
                return NotFound();
            }
            BookAuthor = bookauthor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
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
