using CdvAzure.Functions;
using Lab4.Database.Entities;

namespace Lab4.Services
{
    public interface IAddressesService
    {
        AddressEntity FindAddress(int id);

        IEnumerable<AddressEntity> GetAddresses();

        AddressEntity AddAddress(AddressEntity address);
    }
}