﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public IndexModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public IList<BookCategories> BookCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BookCategory = await _context.BookCategories.ToListAsync();
        }
    }
}
