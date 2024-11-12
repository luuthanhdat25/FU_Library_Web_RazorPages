using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entity;
using FU_Library_Web;

namespace FU_Library_Web.Pages.Borrowbooks
{
    public class EditModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public EditModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BorrowBooks BorrowBooks { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowbooks =  await _context.BorrowBooks.FirstOrDefaultAsync(m => m.BorrowBookId == id);
            if (borrowbooks == null)
            {
                return NotFound();
            }
            BorrowBooks = borrowbooks;
           ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
           ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "StatusName");
           ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(BorrowBooks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowBooksExists(BorrowBooks.BorrowBookId))
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

        private bool BorrowBooksExists(Guid id)
        {
            return _context.BorrowBooks.Any(e => e.BorrowBookId == id);
        }
    }
}
