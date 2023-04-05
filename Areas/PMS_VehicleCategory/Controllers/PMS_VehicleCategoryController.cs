using Microsoft.AspNetCore.Mvc;
using ParkingSystem.DAL;
using ParkingSystem.BAL;
using System.Data;
using ParkingSystem.Areas.PMS_VehicleCategory.Models;

namespace ParkingSystem.Areas.PMS_VehicleCategory.Controllers
{

    [CheckAccess]
    [Area("PMS_VehicleCategory")]
    [Route("PMS_VehicleCategory/[controller]/[action]")]
    public class PMS_VehicleCategoryController : Controller
    {
        string myConnectionString = DALHelper.myConnectionString;

        private IConfiguration Configuration;
        public PMS_VehicleCategoryController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region SelectAll
        public IActionResult Index()
        { 
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtVehicleCategory = dalPMS.PR_PMS_VehicleCategory_SelectAll();
            return View("PMS_VehicleCategoryList", dtVehicleCategory);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int VehicleCategoryID)
        {
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtVehicleCategory = dalPMS.PR_PMS_VehicleCategory_DeleteByPK(VehicleCategoryID);
            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int VehicleCategoryID)
        {
            if (VehicleCategoryID != null)
            {

                PMS_DAL dalPMS = new PMS_DAL();
                DataTable dtVehicleCategory = dalPMS.PR_PMS_VehicleCategory_SelectByPK(VehicleCategoryID);

                PMS_VehicleCategoryModel modelPMS_VehicleCategoryModel = new PMS_VehicleCategoryModel();

                foreach (DataRow dr in dtVehicleCategory.Rows)
                {
                    modelPMS_VehicleCategoryModel.UserID = Convert.ToInt32(dr["UserID"]);
                    modelPMS_VehicleCategoryModel.VehicleCategoryID = Convert.ToInt32(dr["VehicleCategoryID"]);
                    modelPMS_VehicleCategoryModel.VehicleCategory = Convert.ToString(dr["VehicleCategory"]);
                    modelPMS_VehicleCategoryModel.CreationDate = Convert.ToDateTime(dr["Creationdate"]);
                    modelPMS_VehicleCategoryModel.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("PMS_VehicleCategoryAddEdit", modelPMS_VehicleCategoryModel);


            }
            return View("PMS_VehicleCategoryAddEdit");
        }

        #endregion

        #region Save
        public IActionResult Save(PMS_VehicleCategoryModel modelPMS_VehicleCategory)
        {
            PMS_DAL dalPMS = new PMS_DAL();

            if (modelPMS_VehicleCategory.VehicleCategoryID == null)
            {
                DataTable dtVehicleCategory = dalPMS.PR_PMS_VehicleCategory_Insert(modelPMS_VehicleCategory);
            }
            else
            {
                DataTable dtVehicleCategory = dalPMS.PR_PMS_VehicleCategory_UpdateByPK(modelPMS_VehicleCategory);
            }

            return RedirectToAction("Index");

        }

        #endregion

    }
}
