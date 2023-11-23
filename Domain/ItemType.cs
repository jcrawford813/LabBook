namespace LabBook.Domain;

/// <summary>
/// Represents a Type of Item in the Inventory.
/// </summary>
public class ItemType
{
    public ItemType(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    
    public int Id { get; private set; }

    public string Name { get; set; }

    public string Description { get; set; }
}