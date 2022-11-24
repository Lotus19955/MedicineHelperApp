using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineHelper.DataBase.Entities
{
    public class Appointment: IBaseEntity
    {
        [Key]
        [ForeignKey("DoctorVisit")]
        public Guid Id { get; set; }
        public string? DescriptionOfDestination { get; set; }


        public List<MedicineСheckup>? MedicineСheckup { get; set; }
        public List<MedicineProcedure>? MedicineProcedure { get; set; }
        public List<MedicinePrescription>? MedicinePrescription { get; set; }
        public List<Conclusion >? Conclusion { get; set; }
        public DiseaseHistory? DiseaseHistory { get; set; }
        public Guid? DiseaseHistoryId { get; set; }
        public DoctorVisit DoctorVisit { get; set; }
    }
}