using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class DoctorModel
{
    public Guid Id { get; set; }

    [Required] 
    public Guid DoctorPersonalDataId { get; set; }

    [Required] 
    public Guid SpecializationId { get; set; }

    [Required]
    [Remote("CheckDoctorForExistence", "Doctor",
        AdditionalFields = nameof(DoctorPersonalDataId)
                           + "," + nameof(SpecializationId)
                           + "," + nameof(Id)
                           + "," + nameof(UserId),
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The doctor with the same full name and specialization already exists in current clinic.")]
    public Guid ClinicId { get; set; }

    [Required] 
    public Guid JobStatusId { get; set; }
    [Required]
    public Guid UserId { get; set; }
}