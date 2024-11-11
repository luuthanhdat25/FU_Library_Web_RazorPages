using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using System.Text.Json;
using BusinessLayer.Service.Interface;
using BusinessLayer.Dtos;
using FU_Library_Web.Utils;
using DataAccess.Entity;

namespace FU_Library_Web.Areas.Auth.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly DatabaseContext _databaseContext;
        private readonly IUserService _userService;

        private readonly SessionUtils sessionUtils;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
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

            //if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
            //{
            //    ModelState.AddModelError(nameof(Password), "Password must be at least 6 characters long.");
            //    return Page();
            //}

            var user = await _userService.Login(Login);
            
            if (user)
            {
              /*  sessionUtils.SetObjectInSession("UserSession", user);*/


                return Redirect("/Home"); 
            }
            else
            {
            ModelState.AddModelError(string.Empty, "Email or Password is incorrect.");
            }
            return Page();
        }
    }
}
