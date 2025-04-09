namespace Domain;

/// <summary>
/// Represents an Item within the Inventory.
/// </summary>
public class Item(int id, string name, string description, Location? location = null)
{
    public int Id { get; private set; } = id;

    public string Name { get; set; } = name;

    public string Notes { get; set; } = description;

    public Location? Location { get; set; } = location;

}
