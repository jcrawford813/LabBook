namespace Domain;

/// <summary>
/// Represents a Type of Item in the Inventory.
/// </summary>
public class ItemType(int id, string name, string description)
{
    public int Id { get; private set; } = id;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;
}