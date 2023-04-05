using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Areas.PMS_VehicleCategory.Models
{
    public class PMS_VehicleCategoryModel
    {
        public int? VehicleCategoryID { get; set; }
        public int? UserID { get; set; }
        [Required]
        [DisplayName("vehicleCategory")]
        public string VehicleCategory { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }  
    }
    public class PMS_VehicleCategoryDropDownModel
    {
        public int VehicleCategoryID { get; set; }
        public string VehicleCategory { get; set; }
    }
}
