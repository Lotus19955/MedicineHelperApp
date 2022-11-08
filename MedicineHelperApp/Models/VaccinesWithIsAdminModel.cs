using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class VaccinesWithIsAdminModel
{
    public List<VaccineDto> Vaccines { get; set; }
    
    public bool IsEditAllowed { get; set; }
    
}