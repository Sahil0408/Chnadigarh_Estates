using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Net;
using Chandigarh_Estates;
using Chandigarh_estates_web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Chandigarh_estates_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _Context;
        public HomeController(ApplicationDbContext Context)
        {
            _Context = Context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();

        }
        public IActionResult PropertyList()
        {
            return View();
        }
        public IActionResult PropertyType()
        {
            return View();

        }
        public IActionResult PropertyAgent()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View(new Login_Page());
        }
        [HttpPost]

        public IActionResult Login(Login_Page obj)
        {
            Login_Page usr = _Context.Logins.Where(s=>s.Email==obj.Email && s.Password==obj.Password).SingleOrDefault();
            if (usr != null)
            {
                if (usr.IsActive == true)
                {
                    if (usr.RoleId == 1)
                    {
                        return RedirectToAction("Admin");
                    }
                    else
                    {
                        //HttpContext.Session.MyNewSetObject("Users", Usr);

                        return RedirectToAction("Index");
                    }
                }
                else { TempData["message"] = "You Are Blocked to do this Please talk to your admin"; }
            }
            else
            {
                TempData["message"] = "Username or password is incorrect";
            }
            return View(new Login_Page());
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

        [HttpPost]
        public IActionResult ForgotPassword(string Email)
        {
            //Login_Page log = _Context.Logins.Where(s=>s.Email==email).SingleOrDefault();
            
            String SendMailFrom = "alkaraj732@gmail.com";
                String SendMailTo = Email;
                String SendMailSubject = "Forgot password";
            //   String SendMailBody = "Your password is :<b>" + pwd +"<b>";
            String SendMailBody = " Please Click on Link to Reset Your Password" +
                "    https://localhost:7004/Home/ResetPassword";
            



            try
            {
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    MailMessage email = new MailMessage();
                    // START
                    email.From = new MailAddress(SendMailFrom);
                    email.To.Add(SendMailTo);
                    email.CC.Add(SendMailFrom);
                    email.Subject = SendMailSubject;
                    email.Body = SendMailBody;
                    email.IsBodyHtml = true;

                    //END
                    SmtpServer.Timeout = 5000;
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new NetworkCredential(SendMailFrom, "jotwjlveirwmgwvk");
                    SmtpServer.Send(email);

                }
                catch (Exception ex)
                {
                    // error message catch/show
                    string errormsg = ex.Message;

                    //save into database
                    //Email to developer/manager
                }

            TempData["message"] = "Please Check Your Email";
            return View();
        }

        public IActionResult ResetPassword()
        {
            
            return View(new ResetPassword());
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPassword data)
        {
            Login_Page log = _Context.Logins.Where(x=>x.Email==data.Email).SingleOrDefault();
            if (log != null)
            {
                log.Password = data.Password;
                _Context.Logins.Update(log);
                _Context.SaveChanges();
                return RedirectToAction("Login");
            }
            return RedirectToAction("ForgotPassword");
        }

        public List<Country_Table> ListOfCountries()
        {
            return _Context.Countries.ToList();
        }

        public List<State_Table> ListOfStates()
        {
            return _Context.States.ToList();
        }

        public List<State_Table> GetState(int id)
        {
            List<State_Table> obj = _Context.States.Where(s => s.CountryId == id).ToList();

            return obj;
        }
        public List<City_Table> GetCity(int id)
        {
            List<City_Table> cit = _Context.Cities.Where(c => c.StateId == id).ToList();
            return cit;
        }

        public IActionResult AddCompany()
        {
            TempData["State"] = ListOfStates();
            return View(new CompanyDetail());
        }
        [HttpPost]
        public IActionResult AddCompany(CompanyDetail com)
        {
            _Context.Companies.Add(com);
            _Context.SaveChanges();

           return RedirectToAction("ManageCompany");
        }
        [HttpGet]
        public List<CompanyDetail> GetCompany()
        {
            List<CompanyDetail> List = _Context.Companies.ToList();
            return List;
        }

        public IActionResult ManageCompany()
        {
            List<CompanyDetail> List = _Context.Companies.ToList();
            return View(List);
        }

        public IActionResult Registration(int id)
        {
            
            Country_Table obj = _Context.Countries.Where(s => s.CountryId == id).SingleOrDefault();

            TempData["Country"] = ListOfCountries();

            return View(new Registration());
        }

        [HttpPost]
        public IActionResult Registration(Registration obj)
        {
            Registration_Table Dm = new Registration_Table();
            Dm.Fname = obj.Fname;
            Dm.Lname= obj.Lname;
            Dm.PhoneNo = obj.PhoneNo;
            Dm.CityId = obj.CityId;
            Dm.StateId = obj.StateId;
            Dm.CountryId =obj.CountryId;
            _Context.Details.Add(Dm);
            _Context.SaveChanges();

            Login_Page Lm = new Login_Page();
            Lm.Email = obj.Email;
            Lm.Password = obj.Password;
            Lm.RegId = Dm.RegId;
            Lm.RoleId = 2;
            Lm.IsActive = true;
            _Context.Logins.Add(Lm);
            _Context.SaveChanges();
            
            if (obj != null)
            {
                TempData["Message"] = "Data Saved Successfully";
            }
            return RedirectToAction("Login");
        }
        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}