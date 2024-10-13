using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace FU_Library_Web.Areas.Auth.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _databaseContext;

        public IndexModel(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostTrinhLoginAsync()
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);

            if (!regex.IsMatch(Email))
            {
                ModelState.AddModelError(nameof(Email), "Invalid email format.");
                return Page();
            }

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
            {
                ModelState.AddModelError(nameof(Password), "Password must be at least 6 characters long.");
                return Page();
            }

            var userExist = _databaseContext.Users.Where(u => u.Email == Email && u.Password == Password);
            if (userExist.Any())
            {
                return Redirect("/Home");
            }

            ModelState.AddModelError(string.Empty, "Email or Password is incorrect.");
            return Page();
        }
    }
}
