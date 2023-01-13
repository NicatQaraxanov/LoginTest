using IsapiWSDL;
using LoginTest.Models;
using LoginTest.Services;
using LoginTest.Services.Interfaces;
using LoginTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Xml;

namespace LoginTest.Controllers
{
    public class HomeController : Controller
    {

        public readonly ILoginService _loginService;

        public HomeController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Email/Password is in wrong for";
                return RedirectToAction("Login");
            }

            LoginResponse response = new LoginResponse();
            try
            {
                response = await _loginService.LoginWSDL(user.Login, user.Pass);
            }
            catch (Exception)
            {
                TempData["error"] = "Server error. Try again later";
                return RedirectToAction("Login");
            }
            
            UserResponseViewModel userResponse = JsonConvert.DeserializeObject<UserResponseViewModel>(response.@return);

            if(userResponse?.FirstName == null)
            {
                TempData["error"] = "Email/Password is wrong";
                return RedirectToAction("Login");
            }

            TempData["success"] = $@"Great! You have logged in
First Name: {userResponse.FirstName}
Last Name: {userResponse.LastName}
Mobile: {userResponse.Mobile}
Email: {userResponse.Email}
Country ID: {userResponse.CountryID}";

            return RedirectToAction("Login");
        }
    }
}