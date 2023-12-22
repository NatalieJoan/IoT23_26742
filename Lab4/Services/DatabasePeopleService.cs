using Lab3.Database;
using Lab3.Services;
using Lab4.Database.Entities;

namespace CdvAzure.Services
{
    public class DatabasePeopleService : IPeopleService
    {
        private readonly PeopleDb db;

        public DatabasePeopleService(PeopleDb db)
        {
            this.db = db;
        }
        public PersonEntity AddPerson(PersonEntity person)
        {
            var entity = new PersonEntity
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                AddressId = person.AddressId
            };
            db.People.Add(entity);
            db.SaveChanges();
            person.Id = entity.Id;
            return person;
        }

        public PersonEntity FindPerson(int id)
        {
            var person = db.People.First(w => w.Id == id);

            return person;
        }

        public IEnumerable<PersonEntity> GetPeople()
        {
            var peopleList = db.People.Select(s => MapToDTO(s));

            return peopleList;
        }
        public PersonEntity MapToDTO(PersonEntity entity)
        {
            return new PersonEntity
            {
                FirstName = entity.FirstName,
                Id = entity.Id,
                LastName = entity.LastName
            };
        }
    }
}