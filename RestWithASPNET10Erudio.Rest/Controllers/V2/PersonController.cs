using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Rest.Data.DTO.V2;
using RestWithASPNET10Erudio.Rest.Services.Impl.V2;

namespace RestWithASPNET10Erudio.Rest.Controllers.V2;

[ApiController]
[Route("api/[controller]/v2")]
public class PersonController : ControllerBase
{
    private PersonImplV2 _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(PersonImplV2 personService, ILogger<PersonController> logger)
    {
        _personService = personService;
        _logger = logger;
    }
  
    [HttpPost]
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
}