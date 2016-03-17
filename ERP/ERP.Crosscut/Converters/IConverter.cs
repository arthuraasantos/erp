using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities.Commom;

namespace ERP.Crosscut.Converters
{
    public interface IConverter<TOrigin, TDestiny>
        where TOrigin: class
        where TDestiny: AuditableEntity
    {
        TDestiny Convert(TOrigin origin, TDestiny destiny);
        TOrigin Convert(TDestiny origin, TOrigin  destiny);

    }
}
