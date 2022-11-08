using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class VaccineModel
{
    public Guid Id { get; set; }
    [Required]
    [Remote("CheckVaccineForExistence", "Vaccine",
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The vaccine with the same name already exists.")]
    public string PharmName { get; set; }
    public int? EffectiveTermInDays { get; set; }
    public bool IsEnable { get; set; }


    public bool IsLiveLong { get; set; }
}