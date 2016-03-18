using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities.Common;

namespace ERP.Domain.Entities.Organizations
{
    public class Organization: AuditableEntity
    {
        public string Name { get; set; }
        public string RegistrationName { get; set; }
    }
}
