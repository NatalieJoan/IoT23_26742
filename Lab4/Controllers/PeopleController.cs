using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using Microsoft.Extensions.Logging;
using Lab3.Services;
using Lab4.Database.Entities;

namespace Lab3.Controllers.People
{
    [ApiController]
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> logger;
        private readonly IPeopleService peopleService;
        public PeopleController(ILogger<PeopleController> logger, IPeopleService peopleService)
        {
            this.logger = logger;
            this.peopleService = peopleService;
        }

        [HttpGet]
        public IEnumerable<PersonEntity> GetPeople()
        {
            return peopleService.GetPeople();
        }

        [HttpGet("{id}")]
        public PersonEntity FindPerson([FromRoute] int id)
        {
            return peopleService.FindPerson(id);
        }

        [HttpPost]
        public PersonEntity AddPerson([FromBody] PersonEntity person)
        {
            return peopleService.AddPerson(person);
        }
    }
}