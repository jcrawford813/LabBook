namespace Application.Locations;

public interface ILocationCommands
{
    void AddLocation(LocationModel model);

    void RemoveLocation(LocationModel model);
}
