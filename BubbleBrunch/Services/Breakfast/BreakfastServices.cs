
namespace BubbleBrunch.Services.Breakfast
{
public class BreakfastServices : IbreakfastServices
{   
    private static readonly Dictionary<Guid, Models.Breakfast> _breakfasts = new();

    public void CreateBreakfast(Models.Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }
    public Models.Breakfast GetBreakfast(Guid id)
    {
        return _breakfasts[id];
    }

    public void UpsertBreakfast(Models.Breakfast breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;
    }
     public void DeleteBreakfast(Guid id)
    {
        _breakfasts.Remove(id);
    }
  
  
}

}


