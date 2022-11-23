namespace MedicineHelper.Core.DataTransferObjects
{
    public class FluorographyDto
    {
        public DateTime DataOfFluorography { get; set; }
        public DateTime? EndDateOfFluorography { get; set; }
        public string? NumberFluorography { get; set; }
        public bool Result { get; set; }

        public Guid UserDtoId { get; set; }
        public Guid ClinicDtoId { get; set; }
        public ClinicDto? ClinicDto { get; set; }
    }
}