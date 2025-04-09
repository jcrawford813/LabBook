using Application.Interfaces;

namespace Application.ItemTypes;

public class ItemTypeCommands(IDatabase database) : IItemTypeCommands
{
    private readonly IDatabase _database = database;

    public void AddItemType(ItemTypeModel model)
    {
        var itemType = CreateItemTypeFromModel(model);
        _database.ItemTypes.Add(itemType);

        _database.Save();
    }

    public void RemoveItemType(ItemTypeModel model)
    {
        var itemType = CreateItemTypeFromModel(model);
        _database.ItemTypes.Remove(itemType);

        _database.Save();
    }

    private static ItemType CreateItemTypeFromModel(ItemTypeModel model)
    {
        ItemType itemType = new(model.Id, model.Name, model.Description);
        return itemType;
    }
}