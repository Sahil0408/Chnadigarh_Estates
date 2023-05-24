using ChandigarhEstates.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Chnadigarh_Estates.Controllers
{
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Login", "Home");
        }


        public IActionResult Login()
        {
            return View(new Login_Page());
        }
        [HttpPost]

        public async Task<IActionResult> Login(Login_Page obj1)
        {
            // UserDetail usrDetail = new UserDetail();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5079");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method


                HttpResponseMessage response = await client.PostAsJsonAsync("api/Account/CheckLogin", obj1);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    Login_Page _usrDetail = JsonConvert.DeserializeObject<Login_Page>(stringResponse);

                    return RedirectToAction("Admin");
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return View();

        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }



        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ForgotPassword(string email)
        {
            TempData["message"] = "Please Check Your Email";
            return View();
        }

        public IActionResult ResetPassword()
        {

            return View(new ResetPassword());
        }
        public IActionResult Admin()
        {
            return View();
        }
    }
}
