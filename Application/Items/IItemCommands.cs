namespace Application.Items;

public interface IItemCommands
{
    void AddItem(ItemModel model);

    void RemoveItem(ItemModel model);
}