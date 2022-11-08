using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core;
using TheHypochondriac.Core.DataTransferObjects;
using TheHypochondriac.DataBase.Entities;

namespace TheHypochondriac.Models;

public class VisitFullModel : VisitHumanReadableModel
{
    public List<VisitResultDto> VisitResults { get; set; }
    public List<PrescriptionDto> Prescriptions { get; set; }
    public List<VisitCostDto> VistCosts { get; set; }
}