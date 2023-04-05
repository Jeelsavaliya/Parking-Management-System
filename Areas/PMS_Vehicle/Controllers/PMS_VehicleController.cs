using Microsoft.AspNetCore.Mvc;
using ParkingSystem.BAL;
using ParkingSystem.DAL;
using System.Data.SqlClient;
using System.Data;
using ParkingSystem.Areas.PMS_Vehicle.Models;
using ParkingSystem.Areas.PMS_VehicleCategory.Models;

namespace ParkingSystem.Areas.PMS_Vehicle.Controllers
{
    [CheckAccess]
    [Area("PMS_Vehicle")]
    [Route("PMS_Vehicle/[controller]/[action]")]

    public class PMS_VehicleController : Controller
    {
        string myConnectionString = DALHelper.myConnectionString;

        private IConfiguration Configuration;
        public PMS_VehicleController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region SelectAll
        public IActionResult Index()
        {
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtVehicle = dalPMS.PR_PMS_Vehicle_SelectAll();
            return View("PMS_VehicleList", dtVehicle);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int VehicleID)
        {
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtVehicle = dalPMS.PR_PMS_Vehicle_DeleteByPK(VehicleID);
            return RedirectToAction("Index");
        }

        #endregion

        #region Save

        [HttpPost]
        public IActionResult Save(PMS_VehicleModel modelPMS_Vehicle)
        {
            PMS_DAL dalPMS = new PMS_DAL();

            if (modelPMS_Vehicle.VehicleID == null)
            {
                DataTable dtVehicle = dalPMS.PR_PMS_Vehicle_Insert(modelPMS_Vehicle);
            }
            else
            {
                DataTable dtVehicle = dalPMS.PR_PMS_Vehicle_UpdateByPK(modelPMS_Vehicle);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? VehicleID)
        {

            #region VehicleCategory DropDown

            DataTable dtVehicleCDD = new DataTable();
            SqlConnection connVehicleVehicleCategory = new SqlConnection(myConnectionString);
            connVehicleVehicleCategory.Open();

            // Prepare Command
            SqlCommand ObjVehicleCategory = connVehicleVehicleCategory.CreateCommand();
            ObjVehicleCategory.CommandType = CommandType.StoredProcedure;
            ObjVehicleCategory.CommandText = "PR_PMS_VehicleCategory_SelectForDropDown";
            ObjVehicleCategory.Parameters.Add("@UserID", SqlDbType.Int).Value = CV.UserID();
            SqlDataReader ObjSDR1 = ObjVehicleCategory.ExecuteReader();
            dtVehicleCDD.Load(ObjSDR1);
            //connVehicleVehicleCategory.Close();

            List<PMS_VehicleCategoryDropDownModel> VehicleCatdroplist = new List<PMS_VehicleCategoryDropDownModel>();
            foreach (DataRow dr in dtVehicleCDD.Rows)
            {
                PMS_VehicleCategoryDropDownModel VehicleCatlst = new PMS_VehicleCategoryDropDownModel();
                VehicleCatlst.VehicleCategoryID = Convert.ToInt32(dr["VehicleCategoryID"]);
                VehicleCatlst.VehicleCategory = dr["VehicleCategory"].ToString();
                VehicleCatdroplist.Add(VehicleCatlst);
            }
            ViewBag.VehicleCategoryList = VehicleCatdroplist;

            #endregion

            #region Select By PK

            if (VehicleID != null)
            {
                PMS_DAL dalPMS = new PMS_DAL();
                DataTable dtVehicle = dalPMS.PR_PMS_Vehicle_SelectByPK(VehicleID);

                PMS_VehicleModel modelPMS_Vehicle = new PMS_VehicleModel();
                foreach (DataRow dr in dtVehicle.Rows)
                {
                    modelPMS_Vehicle.UserID = (int)dr["UserID"];
                    modelPMS_Vehicle.VehicleCategoryID = (int)dr["VehicleCategoryID"];
                    modelPMS_Vehicle.VehicleCompany = dr["VehicleCompany"].ToString();
                    modelPMS_Vehicle.VehicleModel = dr["VehicleModel"].ToString();
                    modelPMS_Vehicle.VehicleNumber = dr["VehicleNumber"].ToString();
                    modelPMS_Vehicle.OwnerName = dr["OwnerName"].ToString();
                    modelPMS_Vehicle.OwnerMobileNo = dr["OwnerMobileNo"].ToString();
                    modelPMS_Vehicle.CreationDate = (DateTime)dr["CreationDate"];
                    modelPMS_Vehicle.ModificationDate = (DateTime)dr["ModificationDate"];
                }
                return View("PMS_VehicleAddEdit", modelPMS_Vehicle);
            }
            #endregion

            return View("PMS_VehicleAddEdit");
        }

        #endregion
    }
}
