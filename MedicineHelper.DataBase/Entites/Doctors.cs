using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class Doctors
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid VisitsId { get; set; }
        public List<Visits> Visit { get; set; }

        public Guid DoctorsClinicId { get; set; }
        public DoctorsClinic DoctorsClinic { get; set; }

        public Guid DoctorsSpecializationsId { get; set; }
        public DoctorsSpecializations DoctorsSpecialization { get; set; }

    }
}
