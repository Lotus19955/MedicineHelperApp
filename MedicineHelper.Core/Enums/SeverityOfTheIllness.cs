using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MedicineHelper.Core.Enums;

public enum SeverityOfTheIllness
{
    [Display(Name = "Easy")]
    Easy,
    [Display(Name = "Medium Light")]
    MediumLight,
    [Display(Name = "Medium")]
    Medium,
    [Display(Name = "Medium Heavy")]
    MediumHeavy,
    [Display(Name = "Heavy")]
    Heavy
}