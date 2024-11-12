using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Entity;
using FU_Library_Web;

namespace FU_Library_Web.Pages.ReqStatus
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
            return Page();
        }

        [BindProperty]
        public RequestStatus RequestStatus { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RequestStatuses.Add(RequestStatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
