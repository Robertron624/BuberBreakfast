namespace BuberBreakfast.Services.Breakfasts;
using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

public class BreakfastService : IBreakfastService
{

    // Here would go the code to store in a Database, for this example only in memory

    private static readonly Dictionary<Guid, Breakfast>? _breakfasts = new();

    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if(_breakfasts.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }

        return Errors.Breakfasts.NotFound;
    }

    public ErrorOr<UpsertedBreakfast> UpsertBreakfast(Breakfast breakfast)
    {
        var isNewlyCreated = !_breakfasts.ContainsKey(breakfast.Id);

        _breakfasts[breakfast.Id] = breakfast;    

        return new UpsertedBreakfast(isNewlyCreated);    
    }
}