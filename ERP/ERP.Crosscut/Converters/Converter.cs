using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities.Commom;

namespace ERP.Crosscut.Converters
{
    public abstract class Converter<TOrigin, TDestiny>: IConverter<TOrigin,TDestiny>
        where TOrigin: AuditableEntity
        where TDestiny: AuditableEntity
    {
        public abstract TDestiny Convert(TOrigin origin, TDestiny destiny);
        public abstract TOrigin Convert(TDestiny origin, TOrigin destiny);
    }
}
