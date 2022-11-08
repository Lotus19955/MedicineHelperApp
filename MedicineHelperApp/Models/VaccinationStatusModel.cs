using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TheHypochondriac.Models;

public class VaccinationStatusModel
{
    public Guid Id { get; set; }
    [Required]
    [Remote("CheckVaccinationStatusForExistence", "VaccinationStatus",
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The vaccination status with the same name already exists.")]
    public string Name { get; set; }
    public bool IsEnable { get; set; }
}