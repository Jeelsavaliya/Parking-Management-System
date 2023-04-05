using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Areas.PMS_SlotArea.Models;
using ParkingSystem.BAL;
using ParkingSystem.DAL;
using System.Data.SqlClient;
using System.Data;
using ParkingSystem.Areas.PMS_VehicleCategory.Models;

namespace ParkingSystem.Areas.PMS_SlotArea.Controllers
{
    [CheckAccess]
    [Area("PMS_SlotArea")]
    [Route("PMS_SlotArea/[controller]/[action]")]

    public class PMS_SlotAreaController : Controller
    {
        string myConnectionString = DALHelper.myConnectionString;

        private IConfiguration Configuration;
        public PMS_SlotAreaController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region SelectAll
        public IActionResult Index()
        {
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtSlotArea = dalPMS.PR_PMS_SlotArea_SelectAll();
            return View("PMS_SlotAreaList", dtSlotArea);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int SlotAreaID)
        {
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtSlotArea = dalPMS.PR_PMS_SlotArea_DeleteByPK(SlotAreaID);
            return RedirectToAction("Index");
        }

        #endregion

        #region Save

        [HttpPost]
        public IActionResult Save(PMS_SlotAreaModel modelPMS_SlotArea)
        {
            PMS_DAL dalPMS = new PMS_DAL();

            if (modelPMS_SlotArea.SlotAreaID == null)
            {
                DataTable dtSlotArea = dalPMS.PR_PMS_SlotArea_Insert(modelPMS_SlotArea);
            }
            else
            {
                DataTable dtSlotArea = dalPMS.PR_PMS_SlotArea_UpdateByPK(modelPMS_SlotArea);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int SlotAreaID)
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

            if (SlotAreaID != null)
            {
                PMS_DAL dalPMS = new PMS_DAL();
                DataTable dtSlotArea = dalPMS.PR_PMS_SlotArea_SelectByPK(SlotAreaID);

                PMS_SlotAreaModel modelPMS_SlotArea = new PMS_SlotAreaModel();
                foreach (DataRow dr in dtSlotArea.Rows)
                {
                    modelPMS_SlotArea.UserID = (int)dr["UserID"];
                    modelPMS_SlotArea.VehicleCategoryID = (int)dr["VehicleCategoryID"];
                    modelPMS_SlotArea.BuildingName = dr["BuildingName"].ToString();
                    modelPMS_SlotArea.Floor = dr["Floor"].ToString();
                    modelPMS_SlotArea.SlotAreaName = dr["SlotAreaName"].ToString();
                    modelPMS_SlotArea.SlotAreaCode = dr["SlotAreaCode"].ToString();
                    modelPMS_SlotArea.SlotAreaSize = (int)dr["SlotAreaSize"];
                    modelPMS_SlotArea.Status = dr["Status"].ToString();
                    modelPMS_SlotArea.CreationDate = (DateTime)dr["CreationDate"];
                    modelPMS_SlotArea.ModificationDate = (DateTime)dr["ModificationDate"];
                }
                return View("PMS_SlotAreaAddEdit", modelPMS_SlotArea);
            }
            #endregion

            return View("PMS_SlotAreaAddEdit");
        }

        #endregion
    }
}
