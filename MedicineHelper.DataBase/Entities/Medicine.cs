
namespace MedicineHelper.DataBase.Entities
{
    public class Medicine : IBaseEntity
    {
        public Guid Id { get; set; }
        public string NameOfMedicine { get; set; }
        public string? Instructions { get; set; }

        public List<MedicinePrescription> MedicinePrescription { get; set; }
    }
}