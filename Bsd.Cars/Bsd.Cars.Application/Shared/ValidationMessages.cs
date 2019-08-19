namespace Bsd.Cars.Application.Shared
{
    public class ValidationMessages
    {
        public static string GetRequired(string field) => $"{field} is required.";
        public static string GetAtLeastOneSelected(string field) => $"One {field} at least must to be selected.";
        public static string GetTooLong(string field) => $"{field} It´s too long.";
        public static string GetTooShort(string field) => $"{field} It´s too short.";
        public static string GetValidRequired(string field) => $"A valid {field} is required.";
        public static string GetItsInUse(string field) => $"{field} it´s already in use";
    }
}
