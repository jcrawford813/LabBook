namespace Application.Items;

public interface IItemQueries
{
    List<Item> GetItems(string filter);

    Item? GetItem(int id);
}