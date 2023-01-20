namespace BuberBreakfast.ServiceErrors;

using ErrorOr;

public static class Errors
{
    public static class Breakfasts
    {
        public static Error InvalidName => Error.Validation(
            code: "Breakfast.InvalidName",
            description: $"Breakfast name must be at least {Models.Breakfast.MinNameLength} and at most {Models.Breakfast.MaxNameLength} characters");
        
        public static Error InvalidDescription => Error.Validation(
            code: "Breakfast.InvalidDescription",
            description: $"Breakfast Description must be at least {Models.Breakfast.MinDescriptionLength} and at most {Models.Breakfast.MaxDescriptionLength} characters");

        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast was not found"
        );
    }
}