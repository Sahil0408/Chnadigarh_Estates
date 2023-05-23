﻿using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Chandigarh_Estates;
using Chandigarh_estates_web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Chandigarh_Estate_API.Controllers;

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