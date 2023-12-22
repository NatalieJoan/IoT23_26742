using Lab4.Database.Entities;
using Lab3.Database;
using Lab4.Services;

namespace CdvAzure.Service
{
    public class DatabaseAddressesService: IAddressesService
    {
        private readonly PeopleDb db;

        public DatabaseAddressesService(PeopleDb db)
        {
            this.db = db;
        }
        public AddressEntity AddAddress(AddressEntity address){
            var entity = new AddressEntity
            {
                City = address.City,
                Street = address.Street,
                HomeNumber = address.HomeNumber,
                ZipCode = address.ZipCode
            };

            db.Address.Add(entity);
            db.SaveChanges();
            address.AddressId = entity.AddressId;
            return address;
        }
        public IEnumerable<AddressEntity> GetAddresses()
        {
            var addressesList = db.Address.Select(s => MapToDTO(s));

            return addressesList;
        }

       public AddressEntity FindAddress(int id)
        {
            var address = db.Address.First(w => w.AddressId == id);
            return MapToDTO(address);
        }
        
        public AddressEntity MapToDTO(AddressEntity entity)
        {
            return new AddressEntity
            {
                City = entity.City,
                Street = entity.Street,
                HomeNumber = entity.HomeNumber,
                ZipCode = entity.ZipCode,
                AddressId = entity.AddressId
            };
        }
    }
}