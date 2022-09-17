using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class MedicinesPrescriptionsStatuses
    {
        public Guid Id { get; set; }
        public MedicinesPrescriptionsStatus Status { get; set; }

    }
    public enum MedicinesPrescriptionsStatus
    {
        Vaccinated = 1,
        NotVaccined
    }
    }
