using MedicineHelper.Core.DataTransferObjects;
using MessagePack.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicineHelperApp.Models
{
    public class FluorographyModel
    {
        public Guid Id { get; set; }
        public DateTime DataOfFluorography { get; set; }
        public DateTime? EndDateOfFluorography { get; set; }
        public string NumberFluorography { get; set; }
        public bool Result { get; set; }
        public Guid UserId { get; set; }
        public Guid ClinicId { get; set; }
        public SelectList? ClinicList { get; set; }
    }
}