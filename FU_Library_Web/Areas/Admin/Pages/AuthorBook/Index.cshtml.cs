
using DataAccess.Entity;
using DataAccess.Repository.Implement;
using DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FU_Library_Web.Areas.Admin.Pages.AuthorBook
{
    public class IndexModel : PageModel
    {
        //private readonly FU_Library_Web.DatabaseContext _context;
        private readonly IBookAuthorRepository _bookAuthorRepository;

        /*public IndexModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }*/

        public IndexModel(IBookAuthorRepository bookAuthorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
        }

        public IList<BookAuthors> BookAuthor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //BookAuthor = await _context.BookAuthors.ToListAsync();
            BookAuthor = await _bookAuthorRepository.GetAll();
        }
        public async Task<IActionResult> OnPostCreateAsync(string? authorName, string? authorDes)
        {
            var existedName = await _context.BookAuthors.FirstOrDefaultAsync(it => it.FullName.Equals(authorName));
            if (existedName != null)
            {
                return Page();
            }
            else
            {
                BookAuthors newCate = new BookAuthors
                {
                    FullName = authorName,
                    Description = authorDes
                };
                _context.BookAuthors.Add(newCate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var newsItem = await _context.BookAuthors.FindAsync(id);

            if (newsItem == null)
            {
                return NotFound();
            }
            _context.BookAuthors.Remove(newsItem);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
