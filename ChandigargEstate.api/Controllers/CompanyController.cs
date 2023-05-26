using ChandigarhEstates.Data;
using ChandigarhEstates.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace ChandigargEstate.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public CompanyController(ApplicationDbContext Context)
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


        [HttpDelete("DeletecompanyDetails")]

        public ResponseModel<CompanyDetail> DeletecompanyDetails(int id)
        {
            ResponseModel<CompanyDetail> objModel = new ResponseModel<CompanyDetail>();
            try
            {

                List<SqlParameter> parms = new List<SqlParameter>
                  {
                        new SqlParameter{ParameterName ="@id",Value= id}
                  };
                var vm = _Context.Database.ExecuteSqlRaw("EXEC delete_companyDetails_sp @id", parms.ToArray());
                
                

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

        [HttpPut("EditcompanyDetails")]

        public ResponseModel<CompanyDetail> EditcompanyDetails(int id)
        {
            ResponseModel<CompanyDetail> objModel = new ResponseModel<CompanyDetail>();
            try
            {

                List<SqlParameter> parms = new List<SqlParameter>
                {
                        new SqlParameter{ParameterName ="@CompanyId",Value= id },
                       
                  };
                var vm = _Context.Companies.FromSqlRaw("EXEC editcompanyDetails @CompanyId", parms.ToArray()).ToList().FirstOrDefault();



                objModel.IsSuccess = true;
                objModel.StatusCode = 200;
                objModel.Message = "Data deleted Sucessfully";
                objModel.Data = vm;
                
            }
            catch (Exception ex)
            {
                objModel.IsSuccess = false;
                objModel.StatusCode = 500;
                objModel.Message = ex.Message;
                objModel.Data = null;
            }
            return objModel;
        }






        [HttpGet("CompanyList")]
        public List<CompanyDetail> ListCompanies()
        {
            var listComapnies = _Context.Companies.FromSqlRaw("Exec getCompanies", new List<SqlParameter>().ToArray());

            return listComapnies.ToList();
        }
    }
}
