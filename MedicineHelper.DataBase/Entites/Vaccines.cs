using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineHelper.DataBase.Entites
{
    public class Vaccines
    {
        public Guid Id { get; set; }
        public DateTime DateOfEndVaccine { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        
        public Guid CurrenciesId { get; set; }
        public Currencies Currensies { get; set; }
    }
}
