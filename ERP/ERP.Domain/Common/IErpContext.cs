using System;

namespace ERP.Domain.Common
{
    public interface IErpContext
    {
        Guid Id { get; }

        IOrganization Organization { get; }
        ILicence Licence { get; set; }
        IUser User { get; set; }
        IClient Client { get; set; }

        void Validate();
    }
}
