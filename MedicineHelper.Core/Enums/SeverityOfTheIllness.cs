using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MedicineHelper.Core.Enums;

public enum SeverityOfTheIllness
{
    Easy = 1,
    [Display(Name = "Medium Light")]
    MediumLight,
    Medium,
    [Display(Name = "Medium Heavy")]
    MediumHeavy,
    Heavy
}