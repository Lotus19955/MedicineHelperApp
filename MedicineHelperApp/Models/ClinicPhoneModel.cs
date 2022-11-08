using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TheHypochondriac.Models;

public class ClinicPhoneModel
{
    public Guid Id { get; set; }
    [Required]
    [Remote("CheckClinicPhoneForExistence", "ClinicPhone",
        AdditionalFields = "ClinicId",
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "There is already this phone number for this clinic")]
    public string Number { get; set; }
    [HiddenInput]
    [Required]
    public Guid ClinicId { get; set; }
}