
using Application.Interfaces;

namespace Application.Items;

public class ItemCommands : IItemCommands
{
    public ItemCommands(IDatabase database)
    {
        _database = database;
    }

    private readonly IDatabase _database;

    public void AddItem(ItemModel model)
    {
        var item = CreateItemFromModel(model);
        _database.Items.Add(item);

        _database.Save();
    }

    public void RemoveItem(ItemModel model)
    {
        var item = CreateItemFromModel(model);
        _database.Items.Remove(item);

        _database.Save();
    }

    private Item CreateItemFromModel(ItemModel model)
    {
        Item item = new(model.Id, model.Name, model.Notes, new Location(model.LocationId, String.Empty));
        return item;
    }
}