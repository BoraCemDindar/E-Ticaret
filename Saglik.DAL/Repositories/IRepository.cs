using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        IList<T> Listele();
        IList<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        bool Ekle(T item);
        bool Guncelle(T item);
        bool Sil(T item);
        bool Sil(int itemID);
        T Sec(int itemID);
        T Sec(string ItemName);
    }
}
