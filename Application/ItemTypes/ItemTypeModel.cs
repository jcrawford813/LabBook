namespace Application.ItemTypes;

public class ItemTypeModel(int id, string name, string description)
{
    public int Id { get; set; } = id;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;
}