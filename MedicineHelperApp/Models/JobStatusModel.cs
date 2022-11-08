using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TheHypochondriac.Models;

public class JobStatusModel
{
    public Guid Id { get; set; }
    [Required]
    [Remote("CheckJobStatusForExistence", "JobStatus",
        HttpMethod = WebRequestMethods.Http.Post,
        ErrorMessage = "The job status with the same name already exists.")]
    public string Name { get; set; }
    public bool IsEnable { get; set; }
}