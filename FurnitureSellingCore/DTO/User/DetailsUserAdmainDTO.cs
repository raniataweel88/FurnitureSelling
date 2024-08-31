using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.DTO.User
{
    public class DetailsUserAdmainDTO
    {

        public string Email { get; set; }
     
        public string? Phone { get; set; }
        public UserType? UserType { get; set; }
        public string password { get; set; }

        public float? Salary { get; set; }
        public string? PlateNumber { get; set; }
    }
}