namespace MedicineHelperWebAPI.Models.Requests
{
    public class RegisterUserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
