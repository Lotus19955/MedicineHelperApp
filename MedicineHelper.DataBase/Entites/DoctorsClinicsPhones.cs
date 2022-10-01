using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class DoctorsClinicsPhones
    {
        public Guid Id { get; set; }

        
        public Guid DoctorsClinicId { get; set; }
        public DoctorsClinic DoctorsClinic { get; set; }

    }
}
