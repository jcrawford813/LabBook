using Application.Interfaces;

namespace Application.Locations;

public class LocationCommands(IDatabase database) : ILocationCommands
{
    public void AddLocation(LocationModel location)
    {
        Location? parent = null;

        if (location.ParentId != null)
        {
            parent = database.Locations.Get(location.ParentId.Value);
        }

        var newLocation = new Location(location.Id, location.Description, parent);
        database.Locations.Add(newLocation);
    }

    public void RemoveLocation(LocationModel location)
    {
        var model = CreateLocationFromModel(location);
        if (model != null)
        {
            database.Locations.Remove(model);
        }
    }

    private static Location CreateLocationFromModel(LocationModel model)
    {
        Location? parent = null;

        if (model.ParentId != null)
        {
            parent = new Location(model.ParentId.Value, String.Empty);
        }

        return new Location(model.Id, model.Description, parent);
    }
}