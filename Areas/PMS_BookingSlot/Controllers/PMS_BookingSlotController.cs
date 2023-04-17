using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Areas.PMS_BookingSlot.Models;
using ParkingSystem.Areas.PMS_SlotArea.Models;
using ParkingSystem.Areas.PMS_Vehicle.Models;
using ParkingSystem.Areas.PMS_VehicleCategory.Models;
using ParkingSystem.BAL;
using ParkingSystem.DAL;
using System.Data;
using System.Data.SqlClient;

namespace ParkingSystem.Areas.PMS_BookingSlot.Controllers
{
    [CheckAccess]
    [Area("PMS_BookingSlot")]
    [Route("PMS_BookingSlot/[controller]/[action]")]
    public class PMS_BookingSlotController : Controller
    {
        string myConnectionString = DALHelper.myConnectionString;

        private IConfiguration Configuration;
        public PMS_BookingSlotController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region SelectAll
        public IActionResult Index()
        {
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtBookingSlot = dalPMS.PR_PMS_BookingSlot_SelectAll();
            return View("PMS_BookingSlotList", dtBookingSlot);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int SlotID)
        {
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtBookingSlot = dalPMS.PR_PMS_BookingSlot_DeleteByPK(SlotID);
            return RedirectToAction("Index");
        }

        #endregion

        #region Save

        [HttpPost]
        public IActionResult Save(PMS_BookingSlotModel modelPMS_BookingSlot)
        {
            PMS_DAL dalPMS = new PMS_DAL();

            if (modelPMS_BookingSlot.SlotID == null)
            {
                DataTable dtBookingSlot = dalPMS.PR_PMS_BookingSlot_Insert(modelPMS_BookingSlot);
            }
            else
            {
                DataTable dtBookingSlot = dalPMS.PR_PMS_BookingSlot_UpdateByPK(modelPMS_BookingSlot);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Add
        public IActionResult Add(int? SlotID)
        {

            #region VehicleCategory Dropdown

            SqlConnection connBookingSlot1 = new SqlConnection(myConnectionString);
            DataTable dtBookingSlot1 = new DataTable();
            connBookingSlot1.Open();
            SqlCommand ObjCMD1 = connBookingSlot1.CreateCommand();
            ObjCMD1.CommandType = CommandType.StoredProcedure;
            ObjCMD1.CommandText = "PR_PMS_VehicleCategory_SelectForDropDown";
            ObjCMD1.Parameters.Add("@UserID", SqlDbType.Int).Value = CV.UserID();
            SqlDataReader ObjSDR1 = ObjCMD1.ExecuteReader();

            dtBookingSlot1.Load(ObjSDR1);

            List<PMS_VehicleCategoryDropDownModel> list = new List<PMS_VehicleCategoryDropDownModel>();
            foreach (DataRow dr in dtBookingSlot1.Rows)
            {
                PMS_VehicleCategoryDropDownModel vlst = new PMS_VehicleCategoryDropDownModel();
                vlst.VehicleCategoryID = Convert.ToInt32(dr["VehicleCategoryID"]);
                vlst.VehicleCategory = dr["VehicleCategory"].ToString();
                list.Add(vlst);
            }
            ViewBag.VehicleCategoryList = list;

            #endregion

            #region Vehicle Dropdown

            List<PMS_VehicleDropDownModel> list1 = new List<PMS_VehicleDropDownModel>();
            ViewBag.VehicleList = list1;

            #endregion

            #region SlotArea Dropdown
            List<PMS_SlotAreaBuildingDropDownModel> list2 = new List<PMS_SlotAreaBuildingDropDownModel>();
            ViewBag.SlotAreaList = list2;
            #endregion

            #region SelectByPK
            if (SlotID != null)
            {
                PMS_DAL dalLOC = new PMS_DAL();
                DataTable dtBookingSlot = dalLOC.PR_PMS_BookingSlot_SelectByPK(SlotID);

                PMS_BookingSlotModel modelPMS_BookingSlot = new PMS_BookingSlotModel();

                foreach (DataRow dr in dtBookingSlot.Rows)
                {
                    modelPMS_BookingSlot.UserID = Convert.ToInt32(dr["UserID"]);
                    modelPMS_BookingSlot.SlotID = Convert.ToInt32(dr["SlotID"]);
                    modelPMS_BookingSlot.VehicleCategoryID = Convert.ToInt32(dr["VehicleCategoryID"]);

                    modelPMS_BookingSlot.SlotAreaID = Convert.ToInt32(dr["SlotAreaID"]);

                    modelPMS_BookingSlot.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                    modelPMS_BookingSlot.Status = Convert.ToString(dr["Status"]);
                    modelPMS_BookingSlot.BookingDate = Convert.ToDateTime(dr["BookingDate"]);
                    modelPMS_BookingSlot.EntryTime = Convert.ToDateTime(dr["EntryTime"]);
                    modelPMS_BookingSlot.ExitTime = Convert.ToDateTime(dr["ExitTime"]);
                    modelPMS_BookingSlot.Remark = Convert.ToString(dr["Remark"]);
                    modelPMS_BookingSlot.Amount = Convert.ToDecimal(dr["Amount"]);
                    modelPMS_BookingSlot.CreationDate = Convert.ToDateTime(dr["Creationdate"]);
                    modelPMS_BookingSlot.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);   
                }

                DataTable dtSlotVehicle = new DataTable();
                SqlConnection connSlotVehicle = new SqlConnection(myConnectionString);
                connSlotVehicle.Open();

                // Prepare Command
                SqlCommand ObjCMDVehicle = connSlotVehicle.CreateCommand();
                ObjCMDVehicle.CommandType = CommandType.StoredProcedure;
                ObjCMDVehicle.CommandText = "PR_PMS_Vehicle_SelectDropDownByVehicleCategoryID";
                ObjCMDVehicle.Parameters.AddWithValue("@VehicleCategoryID", modelPMS_BookingSlot.VehicleCategoryID);
                ObjCMDVehicle.Parameters.Add("@UserID", SqlDbType.Int).Value = CV.UserID();
                SqlDataReader sdrVehicle = ObjCMDVehicle.ExecuteReader();
                dtSlotVehicle.Load(sdrVehicle);
                //connSlotVehicle.Close();


                List<PMS_VehicleDropDownModel> vListVehicle = new List<PMS_VehicleDropDownModel>();
                foreach (DataRow drVehicle in dtSlotVehicle.Rows)
                {
                    PMS_VehicleDropDownModel vVehicleList = new PMS_VehicleDropDownModel();
                    vVehicleList.VehicleID = Convert.ToInt32(drVehicle["VehicleID"]);
                    vVehicleList.VehicleNumber = drVehicle["VehicleNumber"].ToString();
                    vListVehicle.Add(vVehicleList);
                }
                ViewBag.VehicleList = vListVehicle;

                DataTable dtSlotSlotArea = new DataTable();
                SqlConnection connSlotSlotArea = new SqlConnection(myConnectionString);
                connSlotSlotArea.Open();

                // Prepare Command
                SqlCommand ObjCMDSlotArea = connSlotSlotArea.CreateCommand();
                ObjCMDSlotArea.CommandType = CommandType.StoredProcedure;
                ObjCMDSlotArea.CommandText = "PR_PMS_SlotArea_SelectDropDownByVehicleCategoryID";
                ObjCMDSlotArea.Parameters.AddWithValue("@VehicleCategoryID", modelPMS_BookingSlot.VehicleCategoryID);
                ObjCMDSlotArea.Parameters.AddWithValue("@UserID", modelPMS_BookingSlot.UserID);
                SqlDataReader sdrSlotArea = ObjCMDSlotArea.ExecuteReader();
                dtSlotSlotArea.Load(sdrSlotArea);
                connSlotSlotArea.Close();


                List<PMS_SlotAreaBuildingDropDownModel> vListSlotArea = new List<PMS_SlotAreaBuildingDropDownModel>();
                foreach (DataRow drSlotArea in dtSlotSlotArea.Rows)
                {
                    PMS_SlotAreaBuildingDropDownModel vSlotAreaList = new PMS_SlotAreaBuildingDropDownModel();
                    vSlotAreaList.SlotAreaID = Convert.ToInt32(drSlotArea["SlotAreaID"]);
                    vSlotAreaList.BuildingName = drSlotArea["BuildingName"].ToString();
                    vListSlotArea.Add(vSlotAreaList);
                }
                ViewBag.SlotAreaList = vListSlotArea;

                return View("PMS_BookingSlotAddEdit", modelPMS_BookingSlot);

            }
            #endregion
            return View("PMS_BookingSlotAddEdit");
        }
        #endregion

        #region DropDownByVehicleCategory

        [HttpPost]
        public IActionResult DropDownByVehicleCategory(int VehicleCategoryID)
        {
            SqlConnection connBookingSlot = new SqlConnection(myConnectionString);
            DataTable dtBookingSlot = new DataTable();
            connBookingSlot.Open();
            SqlCommand ObjCMD = connBookingSlot.CreateCommand();
            ObjCMD.CommandType = CommandType.StoredProcedure;
            ObjCMD.CommandText = "PR_PMS_Vehicle_SelectDropDownByVehicleCategoryID";
            ObjCMD.Parameters.AddWithValue("@VehicleCategoryID", VehicleCategoryID);
            ObjCMD.Parameters.AddWithValue("@UserID", CV.UserID());
            SqlDataReader ObjSDR = ObjCMD.ExecuteReader();
            dtBookingSlot.Load(ObjSDR);

            List<PMS_VehicleDropDownModel> vehiclelist = new List<PMS_VehicleDropDownModel>();
            foreach (DataRow dr in dtBookingSlot.Rows)
            {
                PMS_VehicleDropDownModel vehiclelst = new PMS_VehicleDropDownModel();
                vehiclelst.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                vehiclelst.VehicleNumber = dr["VehicleNumber"].ToString();
                vehiclelist.Add(vehiclelst);
            }
            var vModel = vehiclelist;
            return Json(vModel);
        }
        #endregion

        #region DropDownByVehicleCategorySlot

        [HttpPost]
        public IActionResult DropDownByVehicleCategorySlot(int VehicleCategoryID)
        {
            SqlConnection connBookingSlot = new SqlConnection(myConnectionString);
            DataTable dtBookingSlot = new DataTable();
            connBookingSlot.Open();
            SqlCommand ObjCMD = connBookingSlot.CreateCommand();
            ObjCMD.CommandType = CommandType.StoredProcedure;
            ObjCMD.CommandText = "PR_PMS_SlotArea_SelectDropDownByVehicleCategoryID";
            ObjCMD.Parameters.AddWithValue("@VehicleCategoryID", VehicleCategoryID);
            ObjCMD.Parameters.AddWithValue("@UserID", CV.UserID());
            SqlDataReader ObjSDR = ObjCMD.ExecuteReader();
            dtBookingSlot.Load(ObjSDR);

            List<PMS_SlotAreaBuildingDropDownModel> slotArealist = new List<PMS_SlotAreaBuildingDropDownModel>();
            foreach (DataRow dr in dtBookingSlot.Rows)
            {
                PMS_SlotAreaBuildingDropDownModel slotArealst = new PMS_SlotAreaBuildingDropDownModel();
                slotArealst.SlotAreaID = Convert.ToInt32(dr["SlotAreaID"]);
                slotArealst.BuildingName = dr["BuildingName"].ToString();
                slotArealist.Add(slotArealst);
            }
            var cModel = slotArealist;
            return Json(cModel);
        }
        #endregion
    }
}
