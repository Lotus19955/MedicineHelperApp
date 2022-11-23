using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MedicineHelperApp.Models
{
    public class DoctorVisitModel
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateVisit { get; set; }
        public decimal PriceVisit { get; set; }
        public Guid ClinicId { get; set; }
        public SelectList ClinicList { get; set; }
        public Guid DoctorId { get; set; }
        public SelectList DoctorList { get; set; }
        public Guid UserId { get; set; }
        public string? ReturnUrl {get;set;}
    }
}