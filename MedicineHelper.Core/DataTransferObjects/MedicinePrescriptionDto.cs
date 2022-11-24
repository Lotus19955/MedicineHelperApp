namespace MedicineHelper.Core.DataTransferObjects
{
    public class MedicinePrescriptionDto
    {
        public DateTime StartOfAdmission { get; set; }
        public DateTime EndOfAdmission { get; set; }
        public string? MedicineDose { get; set; }
        public decimal MedicinePrice { get; set; }

        public Guid UserId { get; set; }
        public Guid? AppointmentId { get; set; }
        public MedicineDto? MedicinesDto { get; set; }
    }
}