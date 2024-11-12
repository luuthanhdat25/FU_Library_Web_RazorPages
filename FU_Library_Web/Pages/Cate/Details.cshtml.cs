using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FU_Library_Web;
using DataAccess.Entity;

namespace FU_Library_Web.Pages.Cate
{
    public class DetailsModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public DetailsModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public BookCategories BookCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookcategory = await _context.BookCategories.FirstOrDefaultAsync(m => m.BookCategoryId == id);
            if (bookcategory == null)
            {
                return NotFound();
            }
            else
            {
                BookCategory = bookcategory;
            }
            return Page();
        }
    }
}
