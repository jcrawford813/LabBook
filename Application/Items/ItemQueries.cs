using Application.Interfaces;
using LabBook.Domain;

namespace Application.Items;

public class ItemQueries : IItemQueries
{
    public ItemQueries(IDatabase database)
    {
        _database = database;
    }

    private readonly IDatabase _database;

    public Item? GetItem(int id)
    {
        var result = _database.Items.Get(id);
        return result;
    }

    public List<Item> GetItems(string filter)
    {
        var listing = _database.Items.GetAll();

        //TODO: Make this not literal.
        if (!String.IsNullOrEmpty(filter))
        {
            listing = listing.Where(l => l.Name.Contains(filter) || l.Notes.Contains(filter));
        }

        return listing.ToList();
    }
}
