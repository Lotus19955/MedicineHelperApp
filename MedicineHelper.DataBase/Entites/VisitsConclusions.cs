using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class VisitsConclusions
    {
        public Guid Id { get; set; }
        public string? Note { get; set; }


        public Guid VisitsId { get; set; }
        public Visits Visit { get; set; }

        public Guid MedicinesPrescriptonsId { get; set; }
        public MedicinesPrescriptons Prescription { get; set; }

    }
}
