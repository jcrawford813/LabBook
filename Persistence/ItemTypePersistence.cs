using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ItemTypePersistence(DbContext context) : IRepository<ItemType>
{
    private readonly DbContext _context = context;

    public IQueryable<ItemType> GetAll()
    {
        return _context.Set<ItemType>();
    }

    public ItemType? Get(int id)
    {
        return _context.Set<ItemType>().Find(id);
    }

    public void Add(ItemType entity)
    {
        _context.Set<ItemType>().Add(entity);
        _context.SaveChanges();
    }

    public void Remove(ItemType entity)
    {
        _context.Set<ItemType>().Remove(entity);
        _context.SaveChanges();
    }
}