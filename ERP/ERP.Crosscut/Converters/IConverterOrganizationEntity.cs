using ERP.Domain.Entities.Common;

namespace ERP.Crosscut.Converters
{
    public interface IConverterOrganizationEntity<TOrigin, TDestiny>
        where TOrigin: class
        where TDestiny: AuditableOrganizationEntity
    {
        TDestiny Convert(TOrigin origin, TDestiny destiny);
        TOrigin Convert(TDestiny origin, TOrigin  destiny);

    }
}
