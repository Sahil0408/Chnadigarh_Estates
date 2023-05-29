using ChandigarhEstates.Data;
using ChandigarhEstates.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace ChandigarhWebPortal.Controllers
{
    public class CompanyController : Controller
    {
        //private readonly ApplicationDbContext _Context;
        //public CompanyController(ApplicationDbContext Context)
        //{
        //    _Context = Context;
        //}
        public async Task<List<State_Table>> ListOfStates()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5209");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method


                HttpResponseMessage response = await client.GetAsync("/api/Address/GetstateList/");
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    List<State_Table> _usrDetail = JsonConvert.DeserializeObject<List<State_Table>>(stringResponse);

                    return _usrDetail;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return null;
        }

        public async Task<List<City_Table>>GetCity(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5209");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method


                HttpResponseMessage response = await client.DeleteAsync("api/Company/CityList/?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                   List<City_Table> _usrDetail = JsonConvert.DeserializeObject<List<City_Table>>(stringResponse);

                    return _usrDetail;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return null ;
        }
        public IActionResult AddCompany()
        {
            TempData["State"] = ListOfStates();
            return View(new CompanyDetail());
        }
        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyDetail com)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5209");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method


                HttpResponseMessage response = await client.PostAsJsonAsync("api/Company/SaveAddCompany", com);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    CompanyDetail _usrDetail = JsonConvert.DeserializeObject<CompanyDetail>(stringResponse);

                    return RedirectToAction("Admin");
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
           
            return RedirectToAction("ManageCompany");
        }

        [HttpGet]
        public async Task <List<CompanyDetail>> GetCompany()
        
        
        
        
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5209");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method


                HttpResponseMessage response = await client.GetAsync("/api/Company/CompanyList");
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                     List<CompanyDetail> _usrDetail = JsonConvert.DeserializeObject<List<CompanyDetail>>(stringResponse);

                    return _usrDetail;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return null;

        }

        public IActionResult ManageCompany()
        {
            
            return View();
        }

        public async Task<bool> DeleteManageCompany(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5209");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method


                HttpResponseMessage response = await client.DeleteAsync("api/Company/DeletecompanyDetails/?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    CompanyDetail _usrDetail = JsonConvert.DeserializeObject<CompanyDetail>(stringResponse);

                    return true;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return false;
        }

        public async Task<IActionResult> EditManageCompany(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5209");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET Method


                HttpResponseMessage response = await client.GetAsync("api/Company/EditcompanyDetails/?id=" + id);
                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    ResponseModel<CompanyDetail> _usrDetail = JsonConvert.DeserializeObject<ResponseModel<CompanyDetail>>(stringResponse);

                    return RedirectToAction("AddCompany");
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            return View();

        }
    }
}
