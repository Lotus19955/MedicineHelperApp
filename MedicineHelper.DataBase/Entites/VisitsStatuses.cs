using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineHelper.Core.Enums;

namespace MedicineHelper.DataBase.Entites
{
    public class VisitsStatuses
    {
        public Guid Id { get; set; }
        public VisitStatusEnum Status { get; set; }
    }
}
