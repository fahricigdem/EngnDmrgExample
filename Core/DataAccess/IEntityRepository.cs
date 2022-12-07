using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

// Tip IEntitiy ya da ondan türetilmis bir class olabilir, diger tipler classlar vs olamaz
// new'lenebilir olmalidir.
// Sistem sadece veri tabani nesneleri ile calisan bir repository oldu.
namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity, new()
    { 
        List<T> GetAll(Expression<Func<T, bool>> filter=null); 
        T Get(Expression<Func<T, bool>> filter); 
        void Add(T entity); 
        void Update(T entity);
        void Delete(T entity);
    }
}
 