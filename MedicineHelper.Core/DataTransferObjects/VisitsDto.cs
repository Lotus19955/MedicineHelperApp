using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.Core.DataTransferObjects
{
    public class VisitsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime VisitDate { get; set; }
        public decimal Cost { get; set; }
    }
}
