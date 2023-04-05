using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ParkingSystem.Areas.PMS_User.Models
{
    public class PMS_UserModel
    {
        public int? UserID { get; set; }
        //public int? RoleID { get; set; }

        [Required]
        [DisplayName("Pkease Enter User Name")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Pkease Enter Password")]
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
