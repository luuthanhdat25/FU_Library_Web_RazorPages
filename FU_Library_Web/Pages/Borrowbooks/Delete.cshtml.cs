using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FU_Library_Web;
using DataAccess.Entity;

namespace FU_Library_Web.Pages.Borrowbooks
{
    public class DeleteModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public DeleteModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BorrowBooks BorrowBook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowbook = await _context.BorrowBooks.FirstOrDefaultAsync(m => m.BorrowBookId == id);

            if (borrowbook == null)
            {
                return NotFound();
            }
            else
            {
                BorrowBook = borrowbook;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowbook = await _context.BorrowBooks.FindAsync(id);
            if (borrowbook != null)
            {
                BorrowBook = borrowbook;
                _context.BorrowBooks.Remove(BorrowBook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
