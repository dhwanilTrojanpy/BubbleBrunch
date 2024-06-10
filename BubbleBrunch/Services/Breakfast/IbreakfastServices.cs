using BubbleBrunch.Models;
public interface IbreakfastServices
{
    void CreateBreakfast(Breakfast breakfast);
    Breakfast GetBreakfast(Guid id);

    void UpsertBreakfast(Breakfast breakfast);

     void DeleteBreakfast(Guid id);
}