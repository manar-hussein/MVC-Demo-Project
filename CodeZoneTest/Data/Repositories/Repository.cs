using CodeZoneTest.Data.Models;
using CodeZoneTest.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CodeZoneTest.Data.Repositories;
public class Repository<T> :IRepository<T> where T : BaseModel
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public async Task<T> GetByIDAsync(string id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
            return entity.IsDeleted ? null : entity;
        return entity;
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.Where(e => !e.IsDeleted);
    }

    public async Task AddAsync(T entity)
    { 
        await _dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public bool IsDeleted(T entity)
    {
        return entity.IsDeleted;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return GetAll().Where(predicate);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }
}