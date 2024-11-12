﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FU_Library_Web;
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

        public IActionResult OnGet()
        {
        ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return Page();
        }

        [BindProperty]
        public BorrowBooks BorrowBook { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var borrowingStatus = await _context.RequestStatuses
                .FirstOrDefaultAsync(rs => rs.StatusName == "Đang mượn");

            if (borrowingStatus == null)
            {
                ModelState.AddModelError(string.Empty, "The 'Đang mượn' status is not available.");
                return Page();
            }

            BorrowBook.RequestStatusId = borrowingStatus.RequestStatusId;

            _context.BorrowBooks.Add(BorrowBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
