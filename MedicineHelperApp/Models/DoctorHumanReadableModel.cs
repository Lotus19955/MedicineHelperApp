using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class DoctorHumanReadableModel
{
    public Guid Id { get; set; }
    public Guid DoctorPersonalDataId { get; set; }
    public string FullName { get; set; }
    public string Specialization { get; set; }
    public string Clinic { get; set; }
    public Guid JobStatusId { get; set; }
}