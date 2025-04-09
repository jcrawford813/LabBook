using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class LocationPersistence(DbContext context) : IRepository<Location>
{
    private readonly DbContext _context = context;

    public IQueryable<Location> GetAll()
    {
        return _context.Set<Location>();
    }

    public Location? Get(int id)
    {
        return _context.Set<Location>().Find(id);
    }

    public void Add(Location entity)
    {
        _context.Set<Location>().Add(entity);
        _context.SaveChanges();
    }

    public void Remove(Location entity)
    {
        _context.Set<Location>().Remove(entity);
        _context.SaveChanges();
    }
}