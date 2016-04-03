using ERP.Services.PurchaseServices.Dtos.Common;

namespace ERP.Services.PurchaseServices.Converters.Address
{
    public static class ConverterAddressDtoToDomain
    {
        public static Domain.Entities.Common.Address Convert(AddressDto origin, Domain.Entities.Common.Address destiny)
        {
            destiny = new Domain.Entities.Common.Address()
            {
                AddressLine = origin.AddressLine,
                Adjunct = origin.Adjunct,
                City = origin.City,
                District = origin.District,
                Number = origin.Number,
                State = origin.State,
                ZipCode = origin.ZipCode
            };
            
            return destiny;
        }

        public static AddressDto Convert(Domain.Entities.Common.Address origin, AddressDto destiny)
        {
            destiny.AddressLine = origin.AddressLine;
            destiny.Adjunct = origin.Adjunct;
            destiny.City = origin.City;
            destiny.District = origin.District;
            destiny.Number = origin.Number;
            destiny.State = origin.State;
            destiny.ZipCode = origin.ZipCode;
            return destiny;
        }
    }
}
