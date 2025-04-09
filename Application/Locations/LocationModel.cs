namespace Application.Locations;

public class LocationModel(int id, string description, int? parentId = null)
{
    public int Id { get; set; } = id;

    public int? ParentId { get; set; } = parentId;

    public string Description { get; set; } = description;
}