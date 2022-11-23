namespace MedicineHelper.DataBase.Entities
{
    public class Disease : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<DiseaseHistory> DiseaseHistory { get; set; }
    }
}