
using Application.Interfaces;

namespace Application.ItemTypes;

public class ItemTypeQueries(IDatabase database) : IItemTypeQueries
{
    private readonly IDatabase _database = database;

    public ItemType? GetItemType(int id)
    {
        return _database.ItemTypes.Get(id);
    }

    public List<ItemType> GetItemTypes(string filter)
    {
        var types = _database.ItemTypes.GetAll();

        if (!String.IsNullOrEmpty(filter))
            types = types.Where(t => t.Name.Contains(filter) || t.Description.Contains(filter));
        
        return types.ToList();
    }
}
