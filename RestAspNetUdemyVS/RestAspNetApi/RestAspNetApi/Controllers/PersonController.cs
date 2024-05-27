using Microsoft.AspNetCore.Mvc;
using RestAspNetApi.Models;
using RestAspNetApi.Services.Inplementations;

namespace RestAspNetApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase {

        private readonly ILogger<PersonController> _logger;

        private IpersonService _personService;

        public PersonController(ILogger<PersonController> logger, IpersonService personService) {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        
        
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Create(person));
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            return Ok(_personService.Update(person));
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}