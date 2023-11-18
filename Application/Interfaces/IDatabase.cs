using LabBook.Domain;

namespace Application.Interfaces;

public interface IDatabase
{
    IRepository<Item> Items { get; }

    IRepository<ItemType> ItemTypes { get; }

    IRepository<Location> Locations { get; }

    void Save();
}