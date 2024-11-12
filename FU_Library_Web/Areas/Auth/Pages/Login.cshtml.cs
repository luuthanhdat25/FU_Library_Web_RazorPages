using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using System.Text.Json;
using BusinessLayer.Service.Interface;
using BusinessLayer.Dtos;
using FU_Library_Web.Utils;
using DataAccess.Entity;
using DataAccess.Repository.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace FU_Library_Web.Areas.Auth.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly DatabaseContext _databaseContext;
        private readonly IUserRepository _userRepository;

       // private readonly SessionUtils sessionUtils;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //public IndexModel()
        //{

        //}
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public LoginDto Login { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);

            if (!regex.IsMatch(Email))
            {
                ModelState.AddModelError(nameof(Email), "Invalid email format.");
                return Page();
            }

           /* if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
            {
                ModelState.AddModelError(nameof(Password), "Password must be at least 6 characters long.");
                return Page();
            }*/

            var (isValidUser, userAccount) = await _userRepository.ValidateUserAsync(Email, Password);

            if (isValidUser)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userAccount.FullName),
                    new Claim(ClaimTypes.Role, userAccount.UserType.ToString()),
                    new Claim(ClaimTypes.Email, userAccount.Email)
                };

                //Config User to Cookie
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false //Close when browser close
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return Redirect("/Index");
            }

            ModelState.AddModelError(string.Empty, "Email or Password is incorrect.");
            return Page();
        }
    }
}
