namespace ParkingSystem.Areas.PMS_BookingSlot.Models
{
    public class PMS_BookingSlotModel
    {
        public int SlotID { get; set; }
        public int? SlotAreaID { get; set; }
        public int? VehicleID { get; set; }
        public int? VehicleCategoryID { get; set; }
        public int? UserID { get; set; }
        public string Status { get; set; }
        public DateTime BookingDate { get; set; }       
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string Remark { get; set; }
        public decimal? Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }


    }
}
