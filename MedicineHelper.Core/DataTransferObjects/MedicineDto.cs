namespace MedicineHelper.Core.DataTransferObjects
{
    public class MedicineDto
    {
        public Guid Id { get; set; }
        public string NameOfMedicine { get; set; }
        public string Instruction { get; set; }
    }
}