namespace BuberBreakfast.ServiceErrors;

using ErrorOr;

public static class Errors
{
    public static class Breakfasts
    {
        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast was not found"
        );
    }
}