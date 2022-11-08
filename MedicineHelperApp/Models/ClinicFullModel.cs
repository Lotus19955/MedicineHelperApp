using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TheHypochondriac.Models;

public class ClinicFullModel : ClinicShortModel
{
    public List<ClinicPhoneModel> ClinicPhones { get; set; }
}