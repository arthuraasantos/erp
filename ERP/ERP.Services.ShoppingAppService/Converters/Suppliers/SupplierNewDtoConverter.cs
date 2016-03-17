using System;
using ERP.Crosscut.Converters;
using ERP.Domain.Entities;
using ERP.Domain.Entities.Suppliers;
using ERP.Services.ShoppingAppService.Dtos.Supplier;

namespace ERP.Services.ShoppingAppService.Converters.Suppliers
{
    public class SupplierNewDtoConverter: IConverter<SupplierNewDto, Supplier>
    {
        public Supplier Convert(SupplierNewDto origin, Supplier destiny)
        {
            if (destiny == null) destiny = new Supplier();

            destiny.CpfCnpj = origin.CpfCnpj;
            destiny.Email = origin.Email;
            if (destiny.CheckCompany())
                destiny.FantasyName = origin.Name;
            else 
                destiny.Name = origin.Name;

            return destiny;
        }

        public SupplierNewDto Convert(Supplier origin, SupplierNewDto destiny)
        {
            throw new ArgumentException("Método não deve ser utilizado!!");
        }
    }
}
