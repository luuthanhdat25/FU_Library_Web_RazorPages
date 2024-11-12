using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess.Entity;
namespace FU_Library_Web.Areas.Chat
{
    public class IndexModel : PageModel
    {
        public List<Messages> Messages { get; set; }

        public void OnGet()
        {
        }
    }
}
