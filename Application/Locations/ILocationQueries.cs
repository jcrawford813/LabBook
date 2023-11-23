namespace Application.Locations;

public interface ILocationQueries
{
    List<Location> GetLocations(string query);

    Location? GetLocation(int id);
}