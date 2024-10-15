using CompanyDAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDAL.Repos
{
    public class Repo<T> : IRepo<T> where T : class
    {
        protected FlightCompanyDbContext _context {  get; set; }
        private DbSet<T> _dbSet { get; set; }

        public Repo(FlightCompanyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Delete(T entity) => _dbSet.Remove(entity);
        public T? Get(int id) => _dbSet.Find(id);
        public T? Get(QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;
            foreach (String include in options.GetIncludes()) { 
            
                query = query.Include(include); 
            }
            if (options.HasWhere)
            {
                query = query.Where(options.Where);
            }
            return query.FirstOrDefault();
        }

        public void Insert(T entity) => _dbSet.Add(entity);
        public IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;
            foreach (String include in options.GetIncludes()) { 
            
                query = query.Include(include);
            }
            if (options.HasWhere)
            {
                query = query.Where(options.Where);
            }
            if (options.HasOrderBy)
            {
                if (options.HasThenOrderBy)
                {
                    query = query.OrderBy(options.OrderBy).ThenBy(options.ThenOrderBy);

                }
                else
                {
                    query = query.OrderBy(options.OrderBy);
                }
            }
            return query.ToList();
        }

        public void Save() => _context.SaveChanges();

        public void Update(T entity) => _dbSet.Update(entity);


    }
}
