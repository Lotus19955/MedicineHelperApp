using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public enum UsersSexEnum
    {
        Man = 1,
        Women
    }
}
