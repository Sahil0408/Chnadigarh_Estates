using System.Diagnostics;
using Chandigarh_estates_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using ChandigarhEstates.Data;
using ChandigarhEstates.Model;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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
        
        public IActionResult Contact()
        {
            return View();
        }
     
        public async Task<List<Country_Table>> ListOfCountries()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5209");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method


                HttpResponseMessage response = await client.GetAsync("/api/Address/CountriesList/");
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    List<Country_Table> _usrDetail = JsonConvert.DeserializeObject<List<Country_Table>>(stringResponse);

                    return _usrDetail;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return null;
        }

      

        //public List<State_Table> GetState(int id)
        //{
        //    List<State_Table> obj = _Context.States.Where(s => s.CountryId == id).ToList();

        //    return obj;
        //}
        //public List<City_Table> GetCity(int id)
        //{
        //    List<City_Table> cit = _Context.Cities.Where(c => c.StateId == id).ToList();
        //    return cit;
        //}

       

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
        
        
        //public IActionResult GetUsers()
        //{
        //    List<SqlParameter> para = new List<SqlParameter>();
        //    var str = _Context.StoreModels.FromSqlRaw("EXEC GetUsers", para.ToArray());
        //    return Json(str);
        //}

        public List<StoreModel> GetUsers()
        {
            var sm = _Context.StoreModels.FromSqlRaw("GetUsers", new List<SqlParameter>().ToArray());
             return sm.ToList();

        }
        public IActionResult ManageUser()
        {
            return View();
        }


        //public IActionResult AddNewCustomer()
        //{
        //    TempData["Companies"] = ListOfCompanies();
        //    return View(new manageCustomer());
        //}
        //[HttpPost]
        //public IActionResult AddNewCustomer(manageCustomer com)
        //{
        //    _Context.Customers.Add(com);
        //    _Context.SaveChanges();
        //    return RedirectToAction("ManageCustomer");
        //}


        public IActionResult ManageCustomer()
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