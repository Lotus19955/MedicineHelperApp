using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class VaccinesModel
{
    public List<VaccineDto> UserVaccines { get; set; }
    public List<VaccineDto> GlobalVaccines { get; set; }

    public bool IsAdmin { get; set; }
    
}