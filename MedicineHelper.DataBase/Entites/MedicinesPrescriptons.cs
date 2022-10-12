using MedicineHelper.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class MedicinesPrescriptons : IBaceEntity
    {
        public Guid Id { get; set; }
        public DateTime DateOfPrescriptionEnd { get; set; }
        public int MedicineDose { get; set; }
        public int NumberOfMedicinePerDay { get; set; }
        public int DaysOfMedication { get; set; }
        public MedicinesPrescriptionsStatusEnum Status { get; set; }

        public Guid MedicinesId { get; set; }
        public List<Medicines> Medicine { get; set; }

        public Guid VisitsConclusionsId { get; set; }
        public List<VisitsConclusions> VisitsConclusion { get; set; }

    }
}
