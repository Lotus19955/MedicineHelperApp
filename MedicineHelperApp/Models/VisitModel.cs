using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core;
using TheHypochondriac.Core.DataTransferObjects;
using TheHypochondriac.DataBase.Entities;

namespace TheHypochondriac.Models;

public class VisitModel
{
    public Guid Id { get; set; }
    [Required]
    public DateTime DateOfVisit { get; set; }
    [Required]
    public VisitStatus VisitStatus { get; set; }
    [Required]
    [Remote("CheckVisitForExistence", "Visit",
        AdditionalFields = nameof(DateOfVisit)
                           + "," + nameof(UserId) 
                           + "," + nameof(Id),
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The visit with the same bundle of date and doctor already exists.")]
    public Guid DoctorId { get; set; }
    [Required]
    public Guid UserId { get; set; }
}