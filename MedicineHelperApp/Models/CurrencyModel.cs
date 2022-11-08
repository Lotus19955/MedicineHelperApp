using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TheHypochondriac.Models;

public class CurrencyModel
{
    public Guid Id { get; set; }
    [Required]
    [Remote("CheckNameForExistence", "Currency", 
        HttpMethod = WebRequestMethods.Http.Post, 
        ErrorMessage = "Name is already exists.")]
    public string Name { get; set; }
}