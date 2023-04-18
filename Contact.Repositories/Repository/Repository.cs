using Contact.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SqlDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(SqlDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public T Add(T entity)
        {
            dbSet.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach(var includeProp in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (orderBy !=null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }
        //public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, CancellationToken cancellationToken = default)
        //{
        //    IQueryable<T> query = dbSet;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (includeProperties != null)
        //    {
        //        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);
        //        }
        //    }
        //    if (orderBy != null)
        //    {
        //        return await orderBy(query).ToListAsync(cancellationToken);
        //    }
        //    return await query.ToListAsync(cancellationToken);
        //}

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
            _db.SaveChanges();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            _db.SaveChanges();
        }
    }
}
