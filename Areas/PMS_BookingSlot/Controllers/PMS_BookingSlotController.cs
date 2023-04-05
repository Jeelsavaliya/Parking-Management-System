using Microsoft.AspNetCore.Mvc;
using ParkingSystem.BAL;
using ParkingSystem.DAL;
using System.Data;

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
        public IActionResult Delete(int BookingSlotID)
        {
            PMS_DAL dalPMS = new PMS_DAL();
            DataTable dtBookingSlot = dalPMS.PR_PMS_BookingSlot_DeleteByPK(BookingSlotID);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
