using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MedicineHelperApp.Models;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    [Remote("CheckEmailForExistence", "Account",
        HttpMethod = WebRequestMethods.Http.Post, ErrorMessage = "Email is already exists")]
    public string Email { get; set; }


    [Required]
    [StringLength(100, 
        ErrorMessage = 
            "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [Compare(nameof(Password),
        ErrorMessage = "The password and confirmation password do not match.")]
    [DataType(DataType.Password)]
    public string PasswordConfirmation { get; set; }
}