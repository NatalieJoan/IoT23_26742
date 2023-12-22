using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using Microsoft.Extensions.Logging;
using Lab4.Services;
using Lab4.Database.Entities;

namespace Lab4.Controllers.Addresses
{
    [ApiController]
    [Route("address")]
    public class AddressesControlller : ControllerBase
    {
        private readonly ILogger<AddressesControlller> logger;
        private readonly IAddressesService addressesServices;
        public AddressesControlller(ILogger<AddressesControlller> logger, IAddressesService addressesServices)
        {
            this.logger = logger;
            this.addressesServices = addressesServices;
        }

        [HttpGet]
        public IEnumerable<AddressEntity> GetAddresses()
        {
            return addressesServices.GetAddresses();
        }

        [HttpGet("{id}")]
        public AddressEntity FindAddress([FromRoute] int id)
        {
            return addressesServices.FindAddress(id);
        }

        [HttpPost]
        public AddressEntity AddAddress([FromBody] AddressEntity address)
        {
            return addressesServices.AddAddress(address);
        }

    }

}