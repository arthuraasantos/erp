using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using ERP.Domain.Common;
using ERP.Domain.Entities.Common;
using ERP.Domain.Interfaces.Base;
using ERP.Infrastructure.Data.Context.Purchase;


namespace ERP.Infrastructure.Data.Repositories.Base
{
    public class RepositoryBase<T>: IRepositoryBase<T>
        where T: AuditableOrganizationEntity
    {
        protected PurchaseUnitOfWork Uow { get; set; }
        protected IDbConnection Dapper { get; set; }

        public RepositoryBase(IPurchaseUnitOfWork uow)
        {
            
            var unitOfWork = uow as PurchaseUnitOfWork;
            if (unitOfWork == null)
                throw  new ArgumentException($"É obrigatório a utilização de uma unidade de trabalho do tipo {nameof(PurchaseUnitOfWork)}" );

            Uow = unitOfWork;
            Dapper = unitOfWork.Database.Connection;
        }

        public T Delete(T entityForDelete)
        {
            try
            {
                var entity = Uow.Set<T>().FirstOrDefault(e => e.Id == entityForDelete.Id);
                if (entity == null)
                    throw new ArgumentNullException($"Entidade não existe");

                entity.DeleteDate = DateTime.Today;
                Uow.Entry(entity).State = EntityState.Modified;

                return entity;
            }
            catch (Exception)
            {
                //ToDo Implementar log de erro
                throw new Exception("Erro ao deletar");
            }
            
        }

        public T Get(Guid key) => Uow.Set<T>().FirstOrDefault(p => p.Id == key);

        public List<T> GetAll() => Uow.Set<T>().ToList();

        public T Save(T entity)
        {
            var set = Uow.Set<T>();
            if (set.Local.Any(e => e == entity))
                Uow.Entry<T>(entity).State = EntityState.Modified;
            else
                set.Add(entity);

            return entity;
        }

        public void Execute() => Uow.SaveChanges();


    }
}
