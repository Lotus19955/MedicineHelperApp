using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class SpecializationShortModel
{
    public Guid Id { get; set; }
    [Required]
    [Remote("CheckSpecializationForExistence", "Specialization",
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The specialization with the same name already exists.")]
    public string Name { get; set; }
    public bool IsEnable { get; set; }
}