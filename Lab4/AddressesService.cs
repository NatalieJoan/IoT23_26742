
namespace CdvAzure.Functions
{
    public class AddressesService
    {
        private List<Address> addresses { get;} = new List<Address>();

        public Address Add(string city, string street, numberOfHome, zipCode)
        {
            var address = new Address{
                City = city,
                Street = street,
                NumberOfHome = numberOfHome,
                ZipCode = zipCode,
                Id = addresses.Count + 1
            };
            addresses.Add(address);
            return address;
        }

        public Address Update(int id, string city, string street)
        {
            var address = addresses.First(w => w.Id == id);
            address.City = city;
            address.Street = street;
            address.NumberOfHome = numberOfHomr;
            address.ZipCode = zipCode;

            return address;
        }

        public void Delete(int id)
        {
            var address = addresses.First(w => w.Id == id);
            addresses.Remove(address);
        }

        public Address Find(int id)
        {
            return addresses.First(w => w.Id == id);
        }

        public IEnumerable<Address> Get()
        {
            return addresses;
        }
        public class Address
        {
            public int Id { get; set;}
            public string City { get; set; }
            public string Street { get; set;}
            public int NumberOfHome { get; set;}
            public int ZipCode { get; set;}
        }
    }
}