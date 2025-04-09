namespace Application.ItemTypes;

public interface IItemTypeCommands
{
    void AddItemType(ItemTypeModel model);

    void RemoveItemType(ItemTypeModel model);
}