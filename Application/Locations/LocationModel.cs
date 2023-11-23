namespace Application.Locations;

public class LocationModel
{
    public LocationModel(int id, string description, int? parentId = null)
    {
        Id = id;
        Description = description;
        ParentId = parentId;
    }

    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string Description { get; set; }
}