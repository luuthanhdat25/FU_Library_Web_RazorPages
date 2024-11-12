using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FU_Library_Web.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
		}
		public IActionResult OnPostSearchAll(string keysearch , string options)
		{
            return RedirectToPage("/SearchBook/Index", new { keysearch = keysearch, options = options });
        }
	}
}
