using System.ComponentModel;

namespace LabBook.Domain;

/// <summary>
/// Represents a Location for an Item.
/// </summary>s
public class Location 
{
    public Location (int locationId, string description)
        : this(locationId, description, null) { }

    public Location (int locationId, string description, Location? subLocation)
    {
        this.LocationId = locationId;
        this.Description = description;
        this.SubLocation = subLocation;
    }

    public int LocationId { get; private set; }

    public string Description { get; set; }

    public Location? SubLocation { get; set; }

}