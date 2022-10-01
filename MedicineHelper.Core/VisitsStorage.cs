using MedicineHelper.Core.DataTransferObjects;
using System.Data;

namespace MedicineHelper.Core
{
    public class VisitsStorage
    {
        public readonly List<VisitsDto> VisitsList;
        public VisitsStorage ()
        {
            VisitsList = new List<VisitsDto>()
            {
                new VisitsDto
            {
                Id = Guid.NewGuid(),
                Name = "Стамотолог",
                VisitDate = DateTime.Now,
                Cost = 50
            },
            new VisitsDto
            {
                Id = Guid.NewGuid(),
                Name = "Хирург",
                VisitDate = DateTime.Now,
                Cost = 45.5m
            },
            new VisitsDto
            {
                Id = Guid.NewGuid(),
                Name = "Травмотолог",
                VisitDate = DateTime.Now,
                Cost = 40
            },
             new VisitsDto
            {
                Id = Guid.NewGuid(),
                Name = "Окулист",
                VisitDate = DateTime.Now,
                Cost = 35.80m
            },
              new VisitsDto
            {
                Id = Guid.NewGuid(),
                Name = "Психолог",
                VisitDate = DateTime.Now,
                Cost = 70.40m
            },
            };
        }
    }
}
