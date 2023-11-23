namespace LabBook.Domain;

/// <summary>
/// Represents a Location for an Item.
/// </summary>s
public class Location 
{
    public Location (int locationId, string description)
        : this(locationId, description, null) { }

    public Location (int locationId, string description, Location? parentLocation)
    {
        Id = locationId;
        Description = description;
        ParentLocation = parentLocation;
    }

    public int Id { get; private set; }

    public string Description { get; set; }

    public Location? ParentLocation { get; set; }

}