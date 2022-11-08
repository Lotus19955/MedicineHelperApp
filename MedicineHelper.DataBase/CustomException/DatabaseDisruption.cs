using MedicineHelper.DataBase.Entities;

namespace MedicineHelper.DataBase.CustomException;

public class DatabaseDisruptionException : InvalidOperationException
{
    public DatabaseDisruptionException()
        : base($"Trying to cascade delete. " +
               $"The association between current entity and others has been severed, " +
               $"but the relationship is either marked as required or is implicitly required " +
               $"because the foreign key is not nullable.") {}
}