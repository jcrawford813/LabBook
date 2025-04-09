using Application.Interfaces;

namespace Application.Locations;

public class LocationQueries(IDatabase database) : ILocationQueries
{
    private readonly IDatabase _database = database;

    public Location? GetLocation(int id)
    {
        return _database.Locations.Get(id);
    }

    public List<Location> GetLocations(string query)
    {
        var results = _database.Locations.GetAll();

        if (!String.IsNullOrEmpty(query))
            results = results.Where(r => r.Description.Contains(query));
        
        return results.ToList();
    }
}
