﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicineHelper.Core.Enums;

namespace MedicineHelper.DataBase.Entites
{
    public class VaccinationsStatuses
    {
        public Guid Id { get; set; }
        public VaccinationStatusEnum Status { get; set; }
    }
}
