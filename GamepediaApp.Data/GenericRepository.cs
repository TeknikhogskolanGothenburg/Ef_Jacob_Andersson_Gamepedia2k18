using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Data
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class where C : DbContext, new()
    {
        private C _enteties = new C();
        public C Context
        {
            get { return _enteties; }
            set { _enteties = value; }
        }

        public virtual void Add(T entity)
        {
            _enteties.Set<T>().Add(entity);    
        }

        public virtual async void AddAsync(T entity)
        {
            await _enteties.Set<T>().AddAsync(entity);
        }

        public virtual void AddMany(ICollection<T> entities)
        {
            _enteties.Set<T>().AddRange(entities);
        }

        public virtual void Delete(T entity)
        {
            _enteties.Set<T>().Remove(entity);
        }

        public virtual void DeleteMany(ICollection<T> entities)
        {
            _enteties.Set<T>().RemoveRange(entities);
        }

        public virtual ICollection<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _enteties.Set<T>().Where(predicate).ToList<T>();
        }

        public virtual async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _enteties.Set<T>().Where(predicate).ToListAsync<T>();
        }

        public virtual ICollection<T> GetAll()
        {
            return _enteties.Set<T>().ToList();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _enteties.Set<T>().ToListAsync<T>();
        }

        public virtual void Update(T entity)
        {
            _enteties.Set<T>().Update(entity);
        }

        public virtual void UpdateMany(ICollection<T> entities)
        {
            _enteties.Set<T>().UpdateRange(entities);
        }

        public virtual void Save()
        {
            _enteties.SaveChanges();
        }
    }
}
