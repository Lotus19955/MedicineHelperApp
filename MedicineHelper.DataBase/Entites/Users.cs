using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineHelper.Core.Enums;

namespace MedicineHelper.DataBase.Entites
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? SurName { get; set; }
        public DateTime DateOfBirgth { get; set; }
        public UsersSexEnum Sex { get; set; }
    }
}
