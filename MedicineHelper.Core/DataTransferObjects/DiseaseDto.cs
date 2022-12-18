namespace MedicineHelper.Core.DataTransferObjects
{
    public class DiseaseDto
    {
        public Guid Id { get; set; }
        public string NameOfDisease { get; set; }
        public string? ShotDescriptionDisease { get; set; }
    }
}