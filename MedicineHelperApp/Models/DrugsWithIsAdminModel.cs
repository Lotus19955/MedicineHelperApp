using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TheHypochondriac.Core.DataTransferObjects;

namespace TheHypochondriac.Models;

public class DrugsWithIsAdminModel
{
    public List<DrugDto> Drugs { get; set; }
    
    public bool IsEditAllowed { get; set; }
    
}