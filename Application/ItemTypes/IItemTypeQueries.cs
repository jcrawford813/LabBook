namespace Application.ItemTypes;

public interface IItemTypeQueries
{
    ItemType? GetItemType(int id);

    List<ItemType> GetItemTypes(string filter);
}