using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GamepediaApp.Data
{
    public interface IGenericRepository<T> where T : class
    {
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        ICollection<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddAsync(T entity);
        void AddMany(ICollection<T> entities);
        void Delete(T entity);
        void DeleteMany(ICollection<T> entities);
        void Update(T entity);
        void UpdateMany(ICollection<T> entities);
        void Save();
        //T motsvarar mina tables.
    }
}
