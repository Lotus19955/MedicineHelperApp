namespace MedicineHelper.Core.DataTransferObjects
{
    public class MedicineDto
    {
        public Guid Id { get; set; }
        public string NameOfMedicine { get; set; }
        public string Instructions { get; set; }
        public List<MedicinePrescriptionDto> MedicinePrescriptionDto { get; set; }
    }
}