namespace MedicineHelper.Core.DataTransferObjects
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string Name{ get; set; }
        public string Specialization { get; set; }
        public float? Rating { get; set; }

        public List<DoctorVisitDto> DoctorVisitsDto { get; set; }
    }
}