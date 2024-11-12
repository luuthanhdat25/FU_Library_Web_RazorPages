using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entity;
using FU_Library_Web;

namespace FU_Library_Web.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public IndexModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Books> Books { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Books = await _context.Books
                .Include(b => b.BookCategory)
                .Include(b => b.BookAuthor)
                .ToListAsync();
        }
    }
}
