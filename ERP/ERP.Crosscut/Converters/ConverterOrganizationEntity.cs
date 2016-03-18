using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities.Common;

namespace ERP.Crosscut.Converters
{
    public abstract class ConverterOrganizationEntity<TOrigin, TDestiny>: IConverterOrganizationEntity<TOrigin,TDestiny>
        where TOrigin: AuditableEntity
        where TDestiny: AuditableEntity
    {
        public abstract TDestiny Convert(TOrigin origin, TDestiny destiny);
        public abstract TOrigin Convert(TDestiny origin, TOrigin destiny);
    }
}
