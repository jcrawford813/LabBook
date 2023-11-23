namespace LabBook.Domain;

/// <summary>
/// Represents an Item within the Inventory.
/// </summary>
public class Item
{
    public Item(int id, string name, string description)
        :this(id, name, description, null) { }

    public Item(int id, string name, string description, Location? location)
    {
        Id = id;
        Notes = description;
        Name = name;
        Location = location;
    }

    public int Id { get; private set; }

    public string Name { get; set; }

    public string Notes { get; set; }

    public Location? Location { get; set; }

}
