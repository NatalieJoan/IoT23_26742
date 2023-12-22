namespace CdvAzure.Functions
{
    public class AddressesService
    {
        private List<Address> addresses {get;} = new List<Address>();

        public Address Add(string city, string street, int homeNumber, int zipCode)
        {
            var address = new Address{
                City = city,
                Street = street,
                HomeNumber = homeNumber,
                ZipCode = zipCode,
                Id = addresses.Count + 1
            };
            addresses.Add(address);
            return address;
        }

        public Address Update(int id, string city, string street, int homeNumber, int zipCode)
        {
            var address = addresses.First(w => w.Id == id);
            address.City = city;
            address.Street = street;
            address.HomeNumber = homeNumber;
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
            public int HomeNumber { get; set;}
            public int ZipCode { get; set;}
        }
    }
}