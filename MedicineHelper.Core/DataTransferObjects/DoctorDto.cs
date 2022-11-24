namespace MedicineHelper.Core.DataTransferObjects
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Specializacion { get; set; }
        public float? Rating { get; set; }

        public List<DoctorVisitDto> DoctorVisitsDto { get; set; }
    }
}