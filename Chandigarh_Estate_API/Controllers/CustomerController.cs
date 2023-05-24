using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ChandigarhEstates.Data;
using ChandigarhEstates.Model;

namespace Chandigarh_Estate_API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public CustomerController(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        [HttpPost()]
        [ActionName("AddCustomerDetails")]
        public IActionResult AddCustomer(manageCustomer customer)
        {
            _Context.Customers.Add(customer);
            _Context.SaveChanges();

            return Ok();
        }

        [HttpGet()]
        [ActionName("GetUsers")]
        public List<CustomerVM> GetCustomers()
        {
            var cm = _Context.CustomersVM.FromSqlRaw("GetCustomers").ToList();
            
            return cm;
        }



        [HttpDelete()]
        [ActionName("deleteCustomer")]
        public ResponseModel<string> manageCustomer(int id)
        {
            ResponseModel<string> objModel = new ResponseModel<string>();
            try
            {

                List<SqlParameter> parms = new List<SqlParameter>
                {
                            new SqlParameter{ParameterName ="@id",Value= id}
                };
                var vm = _Context.Database.ExecuteSqlRaw(" delete_manageCustomer_sp @id", parms.ToArray());

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


    }
}
