using System.Data;
using Application.Interfaces;
using LabBook.Domain;

namespace Application.Items;

public interface IItemQueries
{
    List<Item> GetItems(string filter);

    Item? GetItem(int id);
}