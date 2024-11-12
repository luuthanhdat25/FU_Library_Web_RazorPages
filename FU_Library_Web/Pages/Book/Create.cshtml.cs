using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Entity;
using FU_Library_Web;
using Microsoft.EntityFrameworkCore;

namespace FU_Library_Web.Pages.Book
{
    public class CreateModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public CreateModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Populate the BookCategoryId and BookAuthorId dropdowns
            ViewData["BookCategoryId"] = new SelectList(_context.BookCategories, "BookCategoryId", "Name");
            ViewData["BookAuthorId"] = new SelectList(_context.BookAuthors, "BookAuthorId", "FullName");

            return Page();
        }

        [BindProperty]
        public Books Books { get; set; } = default!;

        // To handle the selected authors
        [BindProperty]
        public Guid SelectedAuthorIds { get; set; }

        public  IActionResult OnPostAsync()
        {
            if (SelectedAuthorIds != null)
            {
                var authors = _context.BookAuthors
                    .FirstOrDefault(e => e.BookAuthorId == SelectedAuthorIds);

                Books.BookAuthorId = authors.BookAuthorId;
                Books.ImageUrl = "";
            }

            _context.Books.Add(Books);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}
