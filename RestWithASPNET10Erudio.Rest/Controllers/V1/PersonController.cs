using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Rest.Data.DTO.V2;
using RestWithASPNET10Erudio.Rest.Services;

namespace RestWithASPNET10Erudio.Rest.Controllers.V1;

[ApiController]
[Route("api/[controller]/v1")]
public class PersonController : ControllerBase
{
    private IPersonService _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonService personService, ILogger<PersonController> logger)
    {
        _personService = personService;
        _logger = logger;
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<PersonDTO>))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult GetAll()
    {
        _logger.LogInformation("Getting all persons");
        return Ok(_personService.FindAll());
    }
    
    [HttpGet ("{id}")]   
    [ProducesResponseType(200, Type = typeof(PersonDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult GetById(long id)
    {
        _logger.LogInformation("Getting person with ID: {Id}", id);
        var person = _personService.FindById(id);
        
        if (person == null)
        {
            _logger.LogWarning("Person with ID: {Id} not found", id);
            return NotFound();
        }
        
        return Ok(person);
    }
    
    [HttpPost]
    [ProducesResponseType(200, Type = typeof(PersonDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult CreatePerson([FromBody] PersonDTO person)
    {
        _logger.LogInformation("Creating new Person: {firstName}", person.FirstName);
        var createdPerson = _personService.Create(person);
        if (createdPerson == null)
        {
            _logger.LogError("Failed to create new Person: {firstName}", person.FirstName);
            return BadRequest();
        }
        _logger.LogDebug("Person created successfully with ID: {id}", createdPerson.Id);
        return Created("Person created", createdPerson);
    }
    
    [HttpPut]
    [ProducesResponseType(200, Type = typeof(PersonDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult UpdatePerson([FromBody] PersonDTO person)
    {
        _logger.LogInformation("Updating person with ID: {id}", person.Id);
        var updatedPerson = _personService.Update(person);
        if (updatedPerson == null)
        {
            _logger.LogError("Failed to update person with ID: {id}", person.Id);
            return BadRequest();
        }
        _logger.LogDebug("Person with ID: {id} updated successfully", person.Id);
        return Ok(updatedPerson);
    }  
    
    [HttpDelete ("{id}")]
    [ProducesResponseType(204, Type = typeof(PersonDTO))]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    public IActionResult DeletePerson(long id)
    {
        _logger.LogInformation("Deleting person with ID: {Id}", id);
       _personService.Delete(id);
       _logger.LogDebug("Person with ID: {id} deleted successfully", id);
       return NoContent();
    }
}