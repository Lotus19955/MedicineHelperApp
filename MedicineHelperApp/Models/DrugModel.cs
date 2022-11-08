using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core;
using TheHypochondriac.Core.DataTransferObjects;
using TheHypochondriac.DataBase.Entities;

namespace TheHypochondriac.Models;

public class DrugModel
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Producer { get; set; }
    [Required]
    [Remote("CheckDrugForExistence", "Drug",
        AdditionalFields = nameof(Name) 
                           + "," + nameof(Producer)
                           + "," + nameof(Id)
                           + "," + nameof(UserId),
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The drug with the same bundle of name and producer and unit already exists.")]
    public string Unit { get; set; }
    public string? Description { get; set; }
    [Required]
    public DrugStatus Status { get; set; }
    [Required]
    public Guid UserId { get; set; }

}