﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entity;
using FU_Library_Web;

namespace FU_Library_Web.Pages.ReqStatus
{
    public class DeleteModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public DeleteModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RequestStatus RequestStatus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requeststatus = await _context.RequestStatuses.FirstOrDefaultAsync(m => m.RequestStatusId == id);

            if (requeststatus == null)
            {
                return NotFound();
            }
            else
            {
                RequestStatus = requeststatus;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requeststatus = await _context.RequestStatuses.FindAsync(id);
            if (requeststatus != null)
            {
                RequestStatus = requeststatus;
                _context.RequestStatuses.Remove(RequestStatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
