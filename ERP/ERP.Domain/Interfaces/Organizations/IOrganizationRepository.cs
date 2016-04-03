using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Domain.Entities.Organizations;
using ERP.Domain.Interfaces.Base;

namespace ERP.Domain.Interfaces.Organizations
{
    public interface IOrganizationRepository : IRepositoryBase<Organization>
    {
        
    }
}
