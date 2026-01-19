using Microsoft.EntityFrameworkCore;
using RestWithASPNET10Erudio.Rest.Model.Base;
using RestWithASPNET10Erudio.Rest.Model.Context;

namespace RestWithASPNET10Erudio.Rest.Repositories.Impl;

public class GenericRepositoryImpl<T> : IRepository<T> where T : BaseEntity
{
    private PostgresContext _context;
    private DbSet<T> _dataSet;
    
    public GenericRepositoryImpl(PostgresContext context)
    {
        _context = context;
        _dataSet = _context.Set<T>();
    }
    
    public List<T> FindAll()
    {
        return _dataSet.ToList(); 
    }
    
    public T FindById(long id)
    {
        return _dataSet.Find(id); 
    }
    
    public T Create(T item)
    {
         _context.Add(item);
         _context.SaveChanges();
         return item;
    }
    
    public T Update(T item)
    {
        var existingItem =_dataSet.Find(item.Id);
        if (existingItem == null) return null;
        
        _context.Entry(existingItem).CurrentValues.SetValues(item);
        _context.SaveChanges();
        return item;
    }

    public void Delete(long id)
    {
        var existingItem = _dataSet.Find(id);
        if (existingItem == null) return;
        _context.Remove(existingItem);
        _context.SaveChanges();
    }
    
    public bool Exists(long id)
    {
        return _dataSet.Any(e => e.Id == id);
    }
}