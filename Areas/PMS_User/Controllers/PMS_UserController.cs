using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Areas.PMS_User.Models;
using ParkingSystem.DAL;
using System.Data;

namespace ParkingSystem.Areas.PMS_User.Controllers
{

    [Area("PMS_User")]
    [Route("PMS_User/[controller]/[action]")]

    public class PMS_UserController : Controller
    {
        private IConfiguration Configuration;
        public PMS_UserController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(PMS_UserModel modelPMS_User)
        {
            string connstr = this.Configuration.GetConnectionString("myConnectionString");
            string error = null;
            if (modelPMS_User.UserName == null)
            {
                error += "User Name is required";
            }
            if (modelPMS_User.Password == null)
            {
                error += "<br/>Password is required";
            }

            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }
            else
            {
                SEC_DAL dal = new SEC_DAL();
                DataTable dt = dal.PR_PMS_User_SelectByUserNamePassword(connstr, modelPMS_User.UserName, modelPMS_User.Password);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());
                        //HttpContext.Session.SetString("FirstName", dr["FirstName"].ToString());
                        //HttpContext.Session.SetString("LastName", dr["LastName"].ToString());
                        //HttpContext.Session.SetString("Email", dr["Email"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("Index");
                }
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
