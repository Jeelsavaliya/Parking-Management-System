using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Areas.PMS_Vehicle.Models
{
    public class PMS_VehicleModel
    {
        public int? VehicleID { get; set; }
        public int? VehicleCategoryID { get; set; }
        public int? UserID { get; set; }
        [Required]
        [DisplayName("vehicle Company")]
        public string VehicleCompany { get; set; }
        [Required]
        [DisplayName("vehicle Model")]
        public string VehicleModel { get; set; }
        [Required]
        [DisplayName("vehicle Number")]
        public string VehicleNumber { get; set; }
        [Required]
        [DisplayName("Name")]
        public string OwnerName { get; set; }
        [Required]
        [DisplayName("Mobile Number")]
        public string OwnerMobileNo { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
    public class PMS_VehicleDropDownModel
    {
        public int VehicleID { get; set; }
        public string VehicleNumber { get; set; }
    }
}
