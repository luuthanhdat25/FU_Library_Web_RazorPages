using DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FU_Library_Web.Areas.News.Pages
{
    public class CreateModel : PageModel
    {
        private readonly INewsRepository _newRepository;
        public string message { get; set; }
        

        [BindProperty]
        public FU_Library_Web.Models.News news { get; set; }

        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _newRepository.AddNewsAsyns(news);

            message = "News added successfully!";

            return RedirectToPage("./Create");
        }
    }
}
