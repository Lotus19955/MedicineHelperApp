using MedicineHelper.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class Visits : IBaceEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime VisitDate { get; set; }
        public decimal Cost { get; set; }
        public VisitStatusEnum Status { get; set; }

        //public Guid CurrenciesId { get; set; }
        //public Currencies Currensies { get; set; }

        public Guid DoctorsId { get; set; }
        public List<Doctors> VisitedDoctors { get; set; }

        public Guid UsersId { get; set; }
        public List<Users> Users { get; set; }
    }
}
