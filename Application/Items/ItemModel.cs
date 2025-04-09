namespace Application.Items;

public class ItemModel(int id, string name, string notes, int itemTypeId, int locationId)
{
    public int Id { get; private set; } = id;

    public string Name { get; set; } = name;

    public string Notes { get; set; } = notes;

    public int ItemTypeId { get; set; } = itemTypeId;

    public int LocationId { get; set; } = locationId;
}