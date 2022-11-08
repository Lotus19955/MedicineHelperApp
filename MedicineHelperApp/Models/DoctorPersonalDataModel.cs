using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TheHypochondriac.Models;

public class DoctorPersonalDataModel
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(250, MinimumLength = 1)]
    [RegularExpression(@"^[a-zA-Z]+[a-zA-Z\s-]*[a-zA-Z]$",
        ErrorMessage = "Must only use letters and spaces and dash. " +
                       "The first and last symbols is required to be letter.")]
    //[Remote("CheckDoctorPersonalDataForExistence", "DoctorPersonalData",
    //    HttpMethod = WebRequestMethods.Http.Post,
    //    ErrorMessage = "The person with the same full name already exists. " +
    //                   "Check all persons or add a new note.")]
    public string FullName { get; set; }

    [Required]
    public Guid UserId { get; set; }
}