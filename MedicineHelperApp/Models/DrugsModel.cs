using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class DrugsModel
{
    public List<DrugDto> UserDrugs { get; set; }
    public List<DrugDto> GlobalDrugs { get; set; }

    public bool IsAdmin { get; set; }
    
}