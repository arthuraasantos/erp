using System.Collections.Generic;

namespace ERP.Domain.Interfaces.Base
{
    public interface IRepositoryBase<T, TKey>
        where T : class
        where TKey: struct 
   
    {
        T Save(T entity);
        T Get(TKey key);
        List<T> GetAll();
        T Delete(T entity);
        void Execute();
    }
}
