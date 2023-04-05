using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Areas.PMS_SlotArea.Models
{
    public class PMS_SlotAreaModel
    {
        public int? SlotAreaID { get; set; }
        public int? VehicleCategoryID { get; set; }
        public int? UserID { get; set; }
        [Required]
        [DisplayName("Building Name")]
        public string BuildingName { get; set; }
        [Required]
        [DisplayName("Floor")]
        public string Floor { get; set; }
        [Required]
        [DisplayName("SlotArea Name")]
        public string SlotAreaName { get; set; }
        [Required]
        [DisplayName("SlotArea Code")]
        public string SlotAreaCode { get; set; }
        [Required]
        [DisplayName("Area Size")]
        public int? SlotAreaSize { get; set; }
        [Required]
        [DisplayName("Status")]
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
    public class PMS_SlotAreaBuildingDropDownModel
    {
        public int SlotAreaID { get; set; }
        public string BuildingName { get; set; }
    }

    public class PMS_SlotAreaFloorDropDownModel
    {
        public int SlotAreaID { get; set; }
        public string Floor { get; set; }
    }

    public class PMS_SlotAreaNameDropDownModel
    {
        public int SlotAreaID { get; set; }
        public string SlotAreaName { get; set; }
    }
}
