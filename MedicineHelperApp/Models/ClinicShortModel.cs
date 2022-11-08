using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TheHypochondriac.Models;

public class ClinicShortModel 
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Remote("CheckClinicForExistence", "Clinic",
        AdditionalFields = "Name"
                           + "," + nameof(UserId),
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The clinic with the same name and address already exists.")]
    public string Address { get; set; }

    [Required]
    public Guid UserId { get; set; }
}