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
            if (origin == null) return null;
            var address = new AddressDto()
            {
                AddressLine = origin.AddressLine,
                Adjunct = origin.Adjunct,
                City = origin.City,
                District = origin.District,
                Number = origin.Number,
                State = origin.State,
                ZipCode = origin.ZipCode
            };

            destiny = address;

            return destiny;
        }
    }
}
