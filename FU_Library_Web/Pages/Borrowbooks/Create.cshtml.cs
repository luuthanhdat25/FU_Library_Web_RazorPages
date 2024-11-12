using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

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
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var borrowingStatus = await _context.RequestStatuses
                .FirstOrDefaultAsync(rs => rs.StatusName == "Đang mượn");

            if (borrowingStatus == null)
            {
                ModelState.AddModelError(string.Empty, "The 'Đang mượn' status is not available.");
                return Page();
            }

            BorrowBooks.RequestStatusId = borrowingStatus.RequestStatusId;

            _context.BorrowBooks.Add(BorrowBooks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
