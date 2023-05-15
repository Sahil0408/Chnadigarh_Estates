//using Microsoft.AspNetCore.Mvc;
//using Chandigarh_Estates;
//using Chandigarh_Estate_API

//namespace Chandigarh_Estate_API.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class WebApiController : ControllerBase
//    {
//        private readonly ApplicationDbContext _Context;
//        public WebApiController(ApplicationDbContext Context)
//        {
//            _Context = Context;
//        }

//        //[HttpGet("GetAll")]
//        //public ResponseModel<List<Userdetail>> GetDetails()
//        //{
//        //    List<Userdetail> objList = _Context.Details.ToList();


//        //    ResponseModel<List<Userdetail>> objModel = new ResponseModel<List<Userdetail>>();
//        //    objModel.IsSuccess = true;
//        //    objModel.StatusCode = 200;
//        //    objModel.Message = "Data Found Sucessfully";
//        //    objModel.Data = objList;

//        //    return objModel;

//        //}

//        //[HttpPost("/Save")]
//        //public ResponseModel<Userdetail> GetDetails(Userdetail obj)
//        //{
//        //    _Context.Details.Add(obj);
//        //    _Context.SaveChanges();

//        //    ResponseModel<Userdetail> objModel = new ResponseModel<Userdetail>();
//        //    objModel.IsSuccess = true;
//        //    objModel.StatusCode = 200;
//        //    objModel.Message = "Data Saved Sucessfully";
//        //    objModel.Data = obj;

//        //    return objModel;
//        //}

//        //[HttpGet("Getusers/{id}")]
//        //public ResponseModel<Userdetail> GetDetails(int id)
//        //{
//        //    Userdetail std = _Context.Details.Where(s => s.UserId == id).SingleOrDefault();

//        //    ResponseModel<Userdetail> objModel = new ResponseModel<Userdetail>();
//        //    objModel.IsSuccess = true;
//        //    objModel.StatusCode = 200;
//        //    objModel.Message = "Data found Sucessfully";
//        //    objModel.Data = std;

//        //    return objModel;
//        //}

//        //[HttpPost("Edit")]
//        //public ResponseModel<Userdetail> EditGetDetails(Userdetail stu)
//        //{
//        //    _Context.Details.Update(stu);
//        //    _Context.SaveChanges();

//        //    ResponseModel<Userdetail> objModel = new ResponseModel<Userdetail>();
//        //    objModel.IsSuccess = true;
//        //    objModel.StatusCode = 200;
//        //    objModel.Message = "Data Edited Sucessfully";

//        //    return objModel;
//        //}

//        //[HttpGet("Delete")]
//        //public ResponseModel<string> DeleteUser(int id)
//        //{
//        //    ResponseModel<string> objModel = new ResponseModel<string>();
//        //    try
//        //    {
//        //        if (id == 0)
//        //        {
//        //            objModel.IsSuccess = false;
//        //            objModel.StatusCode = 500;
//        //            objModel.Message = "Please enter id";
//        //            return objModel;
//        //        }
//        //        Userdetail student = _Context.Details.Where(m => m.UserId == id).SingleOrDefault();
//        //        _Context.Details.Remove(student);
//        //        _Context.SaveChanges();

//        //        objModel.IsSuccess = true;
//        //        objModel.StatusCode = 200;
//        //        objModel.Message = "Data deleted Sucessfully";

//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        objModel.IsSuccess = false;
//        //        objModel.StatusCode = 500;
//        //        objModel.Message = ex.Message;

//        //    }



//        //    return objModel;
//        //}

//    }
//}
