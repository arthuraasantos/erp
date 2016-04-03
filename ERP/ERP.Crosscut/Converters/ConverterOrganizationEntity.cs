using ERP.Domain.Entities.Common;

namespace ERP.Crosscut.Converters
{
    public abstract class ConverterOrganizationEntity<TOrigin, TDestiny>: IConverterOrganizationEntity<TOrigin,TDestiny>
        where TOrigin: class
        where TDestiny: AuditableBase
    {
        public abstract TDestiny Convert(TOrigin origin, TDestiny destiny);
        public abstract TOrigin Convert(TDestiny origin, TOrigin destiny);
    }
}
