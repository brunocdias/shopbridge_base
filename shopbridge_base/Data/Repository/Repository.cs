using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Graph.Models.TermStore;
using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shopbridge_base.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Shopbridge_Context dbcontext;

        public Repository(Shopbridge_Context _dbcontext)
        {
            this.dbcontext = _dbcontext;
        }

        public IQueryable<T> AsQueryable<T>() 
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<Product>> Get() 
        {
            var result = await dbcontext.Product.AsNoTracking().ToListAsync(); 

            return result ;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await dbcontext.Product
                .FindAsync(id).AsTask(); 

            return result;
        }

        public async Task AddAsync(T item)
        {
            await dbcontext.AddAsync(item).AsTask();

            await dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {    
            dbcontext.Update(item);

            dbcontext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            dbcontext.Remove(dbcontext.Product.Single(a => a.Product_Id == id));

            dbcontext.SaveChanges();
        }
        
    }
}
