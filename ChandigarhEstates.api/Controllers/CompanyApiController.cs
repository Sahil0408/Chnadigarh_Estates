using ChandigarhEstates.Data;
using ChandigarhEstates.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Chandigarh_Estate_API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public CompanyApiController(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        [HttpPost("SaveAddCompany")]       
        public IActionResult SaveAddCompany(CompanyDetail companyDetail)
        {
            _Context.Companies.Add(companyDetail);
            _Context.SaveChanges();

            return Ok();


        }

        [HttpPost()]
        
        public IActionResult EditCompany(CompanyDetail companyDetail)
        {
            _Context.Companies.Update(companyDetail);
            _Context.SaveChanges();

            return Ok();


        }


        [HttpDelete()]
        
        public ResponseModel<string> companyDetails(int id)
        {
            ResponseModel<string> objModel = new ResponseModel<string>();
            try
            {

                  List<SqlParameter> parms = new List<SqlParameter>
                  {
                        new SqlParameter{ParameterName ="@id",Value= id}
                  };
                var vm = _Context.Database.ExecuteSqlRaw(" delete_companyDetails_sp @id", parms.ToArray());

                objModel.IsSuccess = true;
                objModel.StatusCode = 200;
                objModel.Message = "Data deleted Sucessfully";

            }
            catch (Exception ex)
            {
                objModel.IsSuccess = false;
                objModel.StatusCode = 500;
                objModel.Message = ex.Message;
            }
            return objModel;    
        }

        [HttpGet()]
        
        public List<CompanyDetail> ListOfCompanies()
        {
            return _Context.Companies.ToList();
        }

        [HttpGet("CompanyList")]
        public List<CompanyDetail> ListCompanies()
        {
            var listComapnies = _Context.Companies.FromSqlRaw("Exec getCompanies",new List<SqlParameter>().ToArray());

            return listComapnies.ToList();
        }


    }
}
