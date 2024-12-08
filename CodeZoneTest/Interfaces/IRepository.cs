using CodeZoneTest.Data.Models;
using System.Linq.Expressions;
namespace CodeZoneTest.Interfaces;
public interface IRepository<T> where T: BaseModel
{
    public Task<T> GetByIDAsync(string id);
    public IQueryable<T> GetAll();
    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    public Task AddAsync(T entity);
    public void Add(T entity);
    public void Delete(T entity);
    public void Save();
    public void Update(T entity);
    public bool IsDeleted(T entity);
}