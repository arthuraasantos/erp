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
    public class RepositoryOrganizationBase<T>: IRepositoryOrganizationBase<T>
        where T: AuditableOrganizationEntity
    {
        protected PurchaseUnitOfWork Uow { get; set; }
        protected IDbConnection Dapper { get; set; }

        public RepositoryOrganizationBase(IPurchaseUnitOfWork uow)
        {
            var unitOfWork = uow as PurchaseUnitOfWork;
            if (unitOfWork == null) throw  new ArgumentException($"É obrigatório a utilização de uma unidade de trabalho do tipo {nameof(PurchaseUnitOfWork)}" );

            Uow = unitOfWork;
            Dapper = unitOfWork.Database.Connection;
        }

        public T Delete(T entityForDelete)
        {
            try
            {
                var entity = BaseQuery().FirstOrDefault(e => e.Id == entityForDelete.Id);
                if (entity == null)
                    throw new ArgumentNullException($"Entidade não existe");

                entity.DeleteDate = DateTime.Today;
                Uow.Entry(entity).State = EntityState.Modified;

                Execute();
                return entity;
            }
            catch (Exception)
            {
                //ToDo Implementar log de erro
                throw new Exception("Erro ao deletar");
            }
        }

        public T Get(Guid key, Guid organizationId) => BaseQuery().FirstOrDefault(p => p.Id == key && p.OrganizationId == organizationId);

        public List<T> GetAll() => BaseQuery().ToList();

        public T Save(T entity)
        {
            var set = Uow.Set<T>();
            Uow.Entry(entity).State = set.Any(e => e.Id == entity.Id) ? EntityState.Modified : EntityState.Added;
            //Uow.Entry<T>(entity).State = set.Local.Any(e => e.Id == entity.Id) ? EntityState.Modified : EntityState.Added;
            //var ent = Uow.Set<T>().FirstOrDefault(e => e.Id == entity.Id);
            //if (ent == null)
            //    Uow.Entry(entity).State = EntityState.Added;

            //Uow.Entry(entity).State = EntityState.Modified;

            Execute();
            return entity;
        }

        public void Execute() => Uow.SaveChanges();
        public IQueryable<T> BaseQuery() => Uow.Set<T>().Where(p => p.DeleteDate == null);
        public IQueryable<T> BaseWithDeleted() => Uow.Set<T>();
    }
}
