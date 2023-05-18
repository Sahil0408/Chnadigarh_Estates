using Chandigarh_Estates;
using Microsoft.AspNetCore.Mvc;

namespace Chnadigarh_Estates.Controllers
{
    public class UserController : Controller
    {
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: User/ChangePassword
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Perform the logic to change the user's password
            // You can retrieve the user's current password from the database and compare it with the submitted value
            // If the current password is valid, update the user's password with the new one

            // Redirect the user to a success page or display a success message
            return RedirectToAction("Login", "Home");
        }

        

    }
}
