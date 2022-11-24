using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MedicineHelperApp.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Empty Email")]
        [EmailAddress(ErrorMessage = "Incorrect Email")]
        [Remote("CheckEmail","Account", 
            HttpMethod = WebRequestMethods.Http.Post, 
            ErrorMessage = "Email already exists")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Empty password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Empty password")]
        [Compare(nameof(Password), ErrorMessage =("Password does not match"))]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
    }
}