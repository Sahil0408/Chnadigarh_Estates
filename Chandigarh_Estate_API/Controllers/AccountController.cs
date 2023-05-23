using Microsoft.AspNetCore.Mvc;
using Chandigarh_Estates;
using Chandigarh_estates_web.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace Chandigarh_Estate_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public AccountController(ApplicationDbContext Context)
        {
            _Context = Context;
        }

        #region "Add User"
        [HttpPost("RegisterUser")]
        
        public IActionResult RegisterUser(Registration obj)
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

        [HttpPost("checkLogin")]
        
        public Login_Page CheckLogin(Login_Page obj)
        {
            Login_Page usr = _Context.Logins.Where(s => s.Email == obj.Email && s.Password == obj.Password && s.IsActive == true).SingleOrDefault();
            if (usr != null)
            {
                //if (usr.RoleId == 1)
                //{
                //    RedirectToAction("Admin", "Home");
                //}
                //else
                //{
                //    RedirectToAction("Index", "Home");
                //}
                return usr;
            }
            else
            {
                RedirectToAction("Login", "Home");
            }
            return usr;
        }


        #region"DeleteUser"
        [HttpDelete("DeleteUser")]
        
        public ResponseModel<string> registration(int id)
        {
            ResponseModel<string> objModel = new ResponseModel<string>();
            try
            {

                List<SqlParameter> parms = new List<SqlParameter>
                   {
                     new SqlParameter{ParameterName ="@id",Value= id}
                   };
                var vm = _Context.Database.ExecuteSqlRaw(" delete_registration_sp @id", parms.ToArray());
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
        #endregion
        #region"ForgotPassword"
        [HttpPost("ForgotPassword")]
        
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
            return Ok();

        }
        #endregion

        #region"Reset Password"

        [HttpPost("ResetPassword")]
        
        public bool ResetPassword(ResetPassword data)
        {
            Login_Page log = _Context.Logins.Where(x => x.Email == data.Email).SingleOrDefault();
            if (log != null)
            {
                log.Password = data.Password;
                _Context.Logins.Update(log);
                _Context.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion
    }
}