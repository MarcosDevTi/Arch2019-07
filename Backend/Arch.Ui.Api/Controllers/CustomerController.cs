using Arch.Cqrs.Client.Customer;
using Arch.CrossCutting.CqrsContracts;
using Microsoft.AspNetCore.Mvc;

namespace Arch.Ui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly IProcessor _processor;
        public CustomerController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpPost]
        public IActionResult Create(CreateCustomer customer)
        {
            _processor.Send(customer);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get([FromQuery]GetCustomers customers)
        {
            return Ok(_processor.Get(customers));
        }
    }
}