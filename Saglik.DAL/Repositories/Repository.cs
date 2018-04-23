using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet; 

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public bool Ekle(T item)
        {
            _dbSet.Add(item);
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
            return false;
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> sorgu = _dbSet;
            if (filter != null)
                sorgu = sorgu.Where(filter);
            if (orderBy != null)
                sorgu = orderBy(sorgu);
            return sorgu.ToList();
        }
        public T Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> sorgu = _dbSet;
            if (filter != null)
                sorgu = sorgu.Where(filter);
            if (orderBy != null)
                sorgu = orderBy(sorgu);
            return sorgu.FirstOrDefault();
        }
        public bool Guncelle(T item)
        {
            _dbSet.Attach(item);
            _dbContext.Entry(item).State = EntityState.Modified;
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
            }
            return false;

        }

        public IList<T> Listele()
        {
            return _dbSet.ToList();
        }

        public T Sec(string ItemName)
        {
            throw new NotImplementedException();
        }

        public T Sec(int itemID)
        {
            return _dbSet.Find(itemID);
        }

        public bool Sil(int itemID)
        {
            throw new NotImplementedException();
        }

        public bool Sil(T item)
        {
            throw new NotImplementedException();
        }
    }
}
