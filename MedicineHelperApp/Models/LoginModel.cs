using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TheHypochondriac.Models;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }


    [Required]
    [DataType(DataType.Password)]
    [Remote("CheckLoginData", "Account",
        AdditionalFields = "Email",
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "Wrong login or password. Try again or click Forgot password to reset it.")]
    public string Password { get; set; }
}