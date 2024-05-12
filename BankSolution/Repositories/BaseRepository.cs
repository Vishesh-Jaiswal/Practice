using Microsoft.EntityFrameworkCore;
using BankSolution.Interfaces;

public abstract class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity>
    where TEntity : class
{
    protected readonly DbContext _context;

    protected BaseRepository(DbContext context)
    {
        _context = context;
    }

    public TEntity Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity? Delete(TKey key)
    {
        var entity = GetById(key);
        if (entity != null)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        return entity;
    }

    public IList<TEntity>? GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public TEntity? GetById(TKey key)
    {
        return _context.Set<TEntity>().Find(key);
    }

    public TEntity? Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
        return entity;
    }
}