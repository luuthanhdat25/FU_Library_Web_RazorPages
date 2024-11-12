﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entity;
using FU_Library_Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FU_Library_Web.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public IndexModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public List<Books> Books { get; set; } = default!;

        public async Task OnGetAsync(string? keysearch, string? name)
        {
            var query = _context.Books
                .Include(b => b.BookCategory)
                .Include(b => b.BookAuthor)
                .AsQueryable();

            if (name == "book" && !string.IsNullOrEmpty(keysearch) || name == "0")
            {
                query = query.Where(b => b.Title.Contains(keysearch));
            }

            if (name == "bookAuthor" && !string.IsNullOrEmpty(keysearch))
            {
                query = query.Where(b => b.BookAuthor.FullName.Contains(keysearch));
            }

            if (name == "bookcate" && !string.IsNullOrEmpty(keysearch))
            {
                query = query.Where(b => b.BookCategory.Name.Contains(keysearch));
            }

            Books = await query.ToListAsync();
        }


    }
}