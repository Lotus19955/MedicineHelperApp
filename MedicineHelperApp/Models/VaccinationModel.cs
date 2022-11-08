using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MedicineHelperApp.Models;

public class VaccinationModel
{
    public Guid Id { get; set; }

    [Required]
    public DateTime DateOfVaccination { get; set; }

    [Required]
    public Guid VaccinationStatusId { get; set; }

    [Required]
    public Guid ClinicId { get; set; }

    [Required]
    [Remote("CheckVaccinationForExistence", "Vaccination",
        AdditionalFields = nameof(DateOfVaccination)
                           + "," + nameof(ClinicId)
                           + "," + nameof(UserId) 
                           + "," + nameof(Id),
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The vaccination with the same bundle of date and vaccine and clinic already exists.")]
    public Guid VaccineId { get; set; }

    [Required]
    public Guid UserId { get; set; }
}