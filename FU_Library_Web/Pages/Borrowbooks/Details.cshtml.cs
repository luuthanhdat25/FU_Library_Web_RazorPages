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
    public class DetailsModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public DetailsModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public BorrowBooks BorrowBook { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowbook = await _context.BorrowBooks.Include(it => it.User).Include(it =>it.RequestStatus).Include(it => it.Book).FirstOrDefaultAsync(m => m.BorrowBookId == id);
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
    }
}
