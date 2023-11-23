namespace Application.Items;

public class ItemModel
{
    public ItemModel(int id, string name, string notes, int itemTypeId, int locationId)
    {
        Id = id;
        Notes = notes;
        Name = name;
        ItemTypeId = itemTypeId;
        LocationId = locationId;
    }

    public int Id { get; private set; }

    public string Name { get; set; }

    public string Notes { get; set; }

    public int ItemTypeId { get; set; }

    public int LocationId { get; set; }
}