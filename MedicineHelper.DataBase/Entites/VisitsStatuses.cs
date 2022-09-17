using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class VisitsStatuses
    {
        public Guid Id { get; set; }
        public VisitStatus Status { get; set; }

    }

    public enum VisitStatus
    {
        Visited = 1,
        NotVisited
    }
}
