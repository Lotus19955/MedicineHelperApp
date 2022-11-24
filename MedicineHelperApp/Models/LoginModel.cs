using System.ComponentModel.DataAnnotations;

namespace MedicineHelperApp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Empty Email")]
        [EmailAddress(ErrorMessage = "Incorrect email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Empty password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}