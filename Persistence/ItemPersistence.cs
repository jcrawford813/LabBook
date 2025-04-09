using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ItemPersistence(DbContext context) : IRepository<Item>
{
    private readonly DbContext _context = context;

    public IQueryable<Item> GetAll()
    {
        return _context.Set<Item>();
    }

    public Item? Get(int id)
    {
        return _context.Set<Item>().Find(id);
    }

    public void Add(Item entity)
    {
        _context.Set<Item>().Add(entity);
        _context.SaveChanges();
    }

    public void Remove(Item entity)
    {
        _context.Set<Item>().Remove(entity);
        _context.SaveChanges();
    }
}
