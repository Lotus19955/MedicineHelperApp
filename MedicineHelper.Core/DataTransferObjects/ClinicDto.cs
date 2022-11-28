namespace MedicineHelper.Core.DataTransferObjects
{
    public class ClinicDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? OperatingMode { get; set; }
        public string? Contact { get; set; }
        public string? SourceClinicUrl { get; set; }
    }
}