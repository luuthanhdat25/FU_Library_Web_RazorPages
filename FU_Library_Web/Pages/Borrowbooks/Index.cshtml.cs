using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entity;
using FU_Library_Web;

namespace FU_Library_Web.Pages.Borrowbooks
{
    public class IndexModel : PageModel
    {
        private readonly FU_Library_Web.DatabaseContext _context;

        public IndexModel(FU_Library_Web.DatabaseContext context)
        {
            _context = context;
        }

        public IList<BorrowBooks> BorrowBooks { get;set; } = default!;

        public async Task OnGetAsync()
        {
            // Load the borrow books with related entities
            BorrowBook = await _context.BorrowBooks
                .Include(b => b.Book)
                .Include(b => b.RequestStatus)
                .Include(b => b.User)
                .ToListAsync();

            // Retrieve the "Đã mượn" and "Đang mượn" statuses
            var returnedStatus = await _context.RequestStatuses
                .FirstOrDefaultAsync(rs => rs.StatusName == "Đã mượn");
            var borrowingStatus = await _context.RequestStatuses
                .FirstOrDefaultAsync(rs => rs.StatusName == "Đang mượn");

            if (returnedStatus != null && borrowingStatus != null)
            {
                bool hasChanges = false;

                foreach (var borrow in BorrowBook)
                {
                    // If the current date is past the ReturnDate, set the status to "Đã mượn"
                    if (borrow.ReturnDate < DateTime.Now && borrow.RequestStatus.StatusName != "Đã mượn")
                    {
                        borrow.RequestStatusId = returnedStatus.RequestStatusId;
                        hasChanges = true;
                    }
                    // If the current date is not past the ReturnDate, set the status to "Đang mượn"
                    else if (borrow.ReturnDate >= DateTime.Now && borrow.RequestStatus.StatusName != "Đang mượn")
                    {
                        borrow.RequestStatusId = borrowingStatus.RequestStatusId;
                        hasChanges = true;
                    }
                }

                // Save changes if any status was updated
                if (hasChanges)
                {
                    await _context.SaveChangesAsync();
                }
            }
        }

    }
}
