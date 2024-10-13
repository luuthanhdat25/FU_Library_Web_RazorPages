using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FU_Library_Web.Models;

namespace FU_Library_Web.Areas.Book.Pages
{
    public class DetailsModel : PageModel
    {
        public FU_Library_Web.Models.Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            // Simulate hardcoded book data
            Book = new Models.Book
            {
                BookId = Guid.NewGuid(),
                Title = "C# Programming",
                ISBN = "978-3-16-148410-0",
                Edition = "1st Edition",
                Publisher = "Tech Press",
                PublicationYear = "2020",
                Description = "A comprehensive guide to C# programming.",
                AvailabilityStatus = true,
                Image = "https://via.placeholder.com/200",
                BookAuthor = new BookAuthor { FullName = "John Doe" }, // Hardcoded author
                BookCategory = new BookCategory { Name = "Programming" } // Hardcoded category
            };

            return Page();
        }
    }
}
