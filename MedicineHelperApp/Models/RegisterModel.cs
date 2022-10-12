using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MedicineHelperApp.Models
{
    public class RegisterModel
    {

        [Required]
        [EmailAddress]
        [Remote("CheckEmail", "Account",
            HttpMethod = WebRequestMethods.Http.Post, ErrorMessage = "Email is already exists")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string PasswordConfirmation { get; set; }
    }
}
