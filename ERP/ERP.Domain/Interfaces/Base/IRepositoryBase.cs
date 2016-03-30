using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Domain.Interfaces.Base
{
    public interface IRepositoryBase<T>
        where T : class
    {
        T Save(T entity);
        T Get(Guid key);
        List<T> GetAll();
        T Delete(T entity);
        void Execute();
        IQueryable<T> BaseQuery();
        IQueryable<T> BaseWithDeleted();
    }
}
