using Lab4.Database.Entities;

namespace Lab3.Services
{
    public interface IPeopleService
    {
        PersonEntity FindPerson(int id);

        IEnumerable<PersonEntity> GetPeople();

        PersonEntity AddPerson(PersonEntity person);
    }
}