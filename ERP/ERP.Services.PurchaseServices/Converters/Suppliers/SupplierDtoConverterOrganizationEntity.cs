using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities.Suppliers;
using ERP.Services.PurchaseServices.Dtos.Supplier;
using ERP.Services.PurchaseServices.Converters.Address;

namespace ERP.Services.PurchaseServices.Converters.Suppliers
{
    public class SupplierDtoConverterOrganizationEntity : IConverterOrganizationEntity<SupplierDto, Supplier>
    {
        public SupplierDto Convert(Supplier origin, SupplierDto destiny)
        {
            if (destiny == null) destiny = new SupplierDto();
            destiny.Id = origin.Id;
            destiny.Address = ConverterAddressDtoToDomain.Convert(origin.Address, null);
            destiny.FinancialAddress = ConverterAddressDtoToDomain.Convert(origin.FinancialAddress, null);
            destiny.CityRegistration = origin.CityRegistration;
            destiny.Comments = origin.Comments;
            destiny.ContactPeople = origin.ContactPeople;
            destiny.CpfCnpj = origin.CpfCnpj;
            destiny.Email = origin.Email;
            if (origin.CheckCompany())
                destiny.FantasyName = origin.Name;
            else
                destiny.Name = origin.Name;
            destiny.IsCompany = origin.IsCompany;
            destiny.OrganizationId = origin.OrganizationId;
            destiny.Phone = origin.Phone;
            destiny.RegistrationName = origin.RegistrationName;
            destiny.StateRegistration = origin.StateRegistration;

            return destiny;
        }

        public Supplier Convert(SupplierDto origin, Supplier destiny)
        {
            //TODO
            throw new NotImplementedException("Não utilizar este método!");
        }
    }
}
