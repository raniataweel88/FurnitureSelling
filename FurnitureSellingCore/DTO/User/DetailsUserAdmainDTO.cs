using static FurnitureSellingCore.helper.Enums;

namespace FurnitureSellingCore.DTO.User
{
    public class DetailsUserAdmainDTO
    {
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? UserType { get; set; }
        public string? password { get; set; }

        public float? Salary { get; set; }
        public string? PlateNumber { get; set; }
    }
}