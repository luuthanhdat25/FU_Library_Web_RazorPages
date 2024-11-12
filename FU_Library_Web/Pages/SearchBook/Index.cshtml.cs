using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entity;

namespace FU_Library_Web.Pages.SearchBook
{
    public class IndexModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public IndexModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public List<Books> Books { get; set; } = default!;
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; } = 1;

        public const int PageSize = 10;

        public async Task OnGetAsync(string? keysearch, string? options, int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;

            var query = _context.Books
                .Include(b => b.BookCategory)
                .Include(b => b.BookAuthor)
                .AsQueryable();

            if (options == "book" && !string.IsNullOrEmpty(keysearch) || options == "0")
            {
                query = query.Where(b => b.Title.Contains(keysearch));
            }

            if (options == "bookAuthor" && !string.IsNullOrEmpty(keysearch))
            {
                query = query.Where(b => b.BookAuthor.FullName.Contains(keysearch));
            }

            if (options == "bookcate" && !string.IsNullOrEmpty(keysearch))
            {
                query = query.Where(b => b.BookCategory.Name.Contains(keysearch));
            }

            TotalPages = (int)Math.Ceiling(await query.CountAsync() / (double)PageSize);

            Books = await query
                .Skip((pageNumber.Value - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            CurrentPage = pageNumber.Value;
        }


    }
}
