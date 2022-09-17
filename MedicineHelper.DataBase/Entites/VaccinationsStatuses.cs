using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class VaccinationsStatuses
    {
        public Guid Id { get; set; }
        public VaccinationStatus Status { get; set; }
    }

    public enum VaccinationStatus
    {
        PrescriptionIsValid = 1,
        NPrescriptionInvalid
    }
}
