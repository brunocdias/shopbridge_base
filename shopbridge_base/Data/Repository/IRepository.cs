using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable<T>() ;
        
        Task<Product> GetById(int id) ;
        Task<IEnumerable<Product>> Get() ;

        Task AddAsync(T item);
        Task UpdateAsync(T item);

        Task DeleteAsync(int id);
    }
}
