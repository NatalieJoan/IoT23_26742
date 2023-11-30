
namespace CdvAzure.Functions
{
    public class AddressesService
    {
        private List<Address> people { get;} = new List<Address>();

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

        public Address Update(int id, string firstName, string lastName)
        {
            var person = people.First(w => w.Id == id);
            person.FirstName = firstName;
            person.LastName = lastName;

            return person;
        }

        public void Delete(int id)
        {
            var person = people.First(w => w.Id == id);
            people.Remove(person);
        }

        public Person Find(int id)
        {
            return people.First(w => w.Id == id);
        }

        public IEnumerable<Person> Get()
        {
            return people;
        }
        public class Person
        {
            public int Id { get; set;}
            public string FirstName { get; set; }
            public string LastName { get; set;}
        }
    }
}