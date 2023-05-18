using Microsoft.AspNetCore.Mvc;
using Chandigarh_Estates;
using Chandigarh_Estate_API;
using Chandigarh_estates_web.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Chandigarh_Estate_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public WebApiController(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        #region "Save Registration"
        [HttpPost("Save")]
        public IActionResult SaveRegistration(Registration obj)
        {
            Registration_Table Dm = new Registration_Table();
            Dm.Fname = obj.Fname;
            Dm.Lname = obj.Lname;
            Dm.PhoneNo = obj.PhoneNo;
            Dm.CityId = obj.CityId;
            Dm.StateId = obj.StateId;
            Dm.CountryId = obj.CountryId;
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

            ResponseModel<Registration_Table> objModel = new ResponseModel<Registration_Table>();
            objModel.IsSuccess = true;
            objModel.StatusCode = 200;
            objModel.Message = "Data Saved Sucessfully";
            objModel.Data = Dm;

            return Ok();


        }
        #endregion

        [HttpPost("AddCompanyDetails")]
        public IActionResult SaveAddCompany(CompanyDetail companyDetail)
        {
            _Context.Companies.Add(companyDetail);
            _Context.SaveChanges();

            return Ok();


        }

        [HttpDelete("deleteCompany")]
        public string companyDetails(int id)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter{ParameterName ="@id",Value= id}
            };
            var vm = _Context.Database.ExecuteSqlRaw(" delete_companyDetails_sp @id", parms.ToArray());

            return "User Deleted Successfully";
        }

        [HttpDelete("deleteCustomer")]
        public string manageCustomer(int id)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter{ParameterName ="@id",Value= id}
            };
            var vm = _Context.Database.ExecuteSqlRaw(" delete_manageCustomer_sp @id", parms.ToArray());

            return "User Deleted Successfully";
        }

        [HttpDelete("DeleteRegistration")]
        public string registration(int id)
        {
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter{ParameterName ="@id",Value= id}
            };
            var vm = _Context.Database.ExecuteSqlRaw(" delete_registration_sp @id", parms.ToArray());

            return "User Deleted Successfully";
        }

        //[HttpGet("ForgotPassword")]
        //public string ForgotPassword123(string email)
        //{

        //    var obj = _Context.Logins.Where(m => m.Email == email).SingleOrDefault();
        //    var pass = obj.Password;

        //    return pass;
        //}

        //[HttpPost("Save")]
        //public ResponseModel<Employees> GetStudent(Employees obj)
        //{
        //    _db.Employees_DB.Add(obj);
        //    _db.SaveChanges();

        //    ResponseModel<Employees> objModel = new ResponseModel<Employees>();
        //    objModel.IsSuccess = true;
        //    objModel.StatusCode = 200;
        //    objModel.Message = "Data Saved Sucessfully";
        //    objModel.Data = obj;

        //    return objModel;
        //}

        //[HttpGet("GetAll")]
        //public ResponseModel<List<Userdetail>> GetDetails()
        //{
        //    List<Userdetail> objList = _Context.Details.ToList();


        //    ResponseModel<List<Userdetail>> objModel = new ResponseModel<List<Userdetail>>();
        //    objModel.IsSuccess = true;
        //    objModel.StatusCode = 200;
        //    objModel.Message = "Data Found Sucessfully";
        //    objModel.Data = objList;

        //    return objModel;

        //}

        //[HttpPost("/Save")]
        //public ResponseModel<Userdetail> GetDetails(Userdetail obj)
        //{
        //    _Context.Details.Add(obj);
        //    _Context.SaveChanges();

        //    ResponseModel<Userdetail> objModel = new ResponseModel<Userdetail>();
        //    objModel.IsSuccess = true;
        //    objModel.StatusCode = 200;
        //    objModel.Message = "Data Saved Sucessfully";
        //    objModel.Data = obj;

        //    return objModel;
        //}

        //[HttpGet("Getusers/{id}")]
        //public ResponseModel<Userdetail> GetDetails(int id)
        //{
        //    Userdetail std = _Context.Details.Where(s => s.UserId == id).SingleOrDefault();

        //    ResponseModel<Userdetail> objModel = new ResponseModel<Userdetail>();
        //    objModel.IsSuccess = true;
        //    objModel.StatusCode = 200;
        //    objModel.Message = "Data found Sucessfully";
        //    objModel.Data = std;

        //    return objModel;
        //}

        //[HttpPost("Edit")]
        //public ResponseModel<Userdetail> EditGetDetails(Userdetail stu)
        //{
        //    _Context.Details.Update(stu);
        //    _Context.SaveChanges();

        //    ResponseModel<Userdetail> objModel = new ResponseModel<Userdetail>();
        //    objModel.IsSuccess = true;
        //    objModel.StatusCode = 200;
        //    objModel.Message = "Data Edited Sucessfully";

        //    return objModel;
        //}

        //[HttpGet("Delete")]
        //public ResponseModel<string> DeleteUser(int id)
        //{
        //    ResponseModel<string> objModel = new ResponseModel<string>();
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            objModel.IsSuccess = false;
        //            objModel.StatusCode = 500;
        //            objModel.Message = "Please enter id";
        //            return objModel;
        //        }
        //        Userdetail student = _Context.Details.Where(m => m.UserId == id).SingleOrDefault();
        //        _Context.Details.Remove(student);
        //        _Context.SaveChanges();

        //        objModel.IsSuccess = true;
        //        objModel.StatusCode = 200;
        //        objModel.Message = "Data deleted Sucessfully";

        //    }
        //    catch (Exception ex)
        //    {
        //        objModel.IsSuccess = false;
        //        objModel.StatusCode = 500;
        //        objModel.Message = ex.Message;

        //    }



        //    return objModel;
        //}

    }
}
