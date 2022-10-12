using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class DoctorsSpecializations : IBaceEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
