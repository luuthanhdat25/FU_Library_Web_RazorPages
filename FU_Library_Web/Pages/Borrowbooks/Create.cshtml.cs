using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Entity;
using FU_Library_Web;

namespace FU_Library_Web.Pages.Borrowbooks
{
    public class CreateModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public CreateModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BorrowBooks BorrowBooks { get; set; } = default!;

        public Books Book { get; set; } // Thêm để lấy thông tin chi tiết sách

        public IActionResult OnGet(Guid? bookId)
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description");
            ViewData["RequestStatusId"] = new SelectList(_context.RequestStatuses, "RequestStatusId", "StatusName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");

            if (bookId.HasValue)
            {
                Book = _context.Books.FirstOrDefault(b => b.BookId == bookId.Value);

                if (Book == null)
                {
                    return NotFound();
                }
                BorrowBooks.BookId = bookId.Value; // Gán BookId mặc định
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BorrowBooks.Add(BorrowBooks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
