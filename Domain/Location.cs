namespace Domain;

/// <summary>
/// Represents a Location for an Item.
/// </summary>s
public class Location(int locationId, string description, Location? parentLocation = null)
{
    public int Id { get; private set; } = locationId;

    public string Description { get; set; } = description;

    public Location? ParentLocation { get; set; } = parentLocation;

}