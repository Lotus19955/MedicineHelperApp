using MedicineHelper.Core.DataTransferObjects;
using System.Data;

namespace MedicineHelper.Core
{
    public class VisitsStorage
    {
        public readonly List<VisitDto> VisitsList;
        public VisitsStorage ()
        {
            VisitsList = new List<VisitDto>()
            {
                new VisitDto
            {
                Id = Guid.NewGuid(),
                Name = "Стамотолог",
                VisitDate = DateTime.Now,
                Cost = 50
            },
            new VisitDto
            {
                Id = Guid.NewGuid(),
                Name = "Хирург",
                VisitDate = DateTime.Now,
                Cost = 45.5m
            },
            new VisitDto
            {
                Id = Guid.NewGuid(),
                Name = "Травмотолог",
                VisitDate = DateTime.Now,
                Cost = 40
            },
             new VisitDto
            {
                Id = Guid.NewGuid(),
                Name = "Окулист",
                VisitDate = DateTime.Now,
                Cost = 35.80m
            },
              new VisitDto
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
