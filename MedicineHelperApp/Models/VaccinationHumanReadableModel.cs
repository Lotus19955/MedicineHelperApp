using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;
using TheHypochondriac.DataBase.Entities;

namespace TheHypochondriac.Models;

public class VaccinationHumanReadableModel
{
    public Guid Id { get; set; }
    public DateTime DateOfVaccination { get; set; }
    public Guid VaccinationStatusId { get; set; }
    public string Clinic { get; set; }
    public string Vaccine { get; set; }
}