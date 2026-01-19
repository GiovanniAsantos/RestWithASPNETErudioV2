// csharp

using RestWithASPNET10Erudio.Rest.Data.Converter.Impl;
using RestWithASPNET10Erudio.Rest.Data.DTO.V2;
using RestWithASPNET10Erudio.Rest.Model;
using RestWithASPNET10Erudio.Rest.Repositories;

namespace RestWithASPNET10Erudio.Rest.Services.Impl.V1;

public class PersonImpl : IPersonService
{
    private IRepository<Person> _repository;
    private readonly PersonConverter _converter; // assegure que este converter trabalha com V1 DTOs

    public PersonImpl(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }

    public List<PersonDTO> FindAll()
    {
        return _converter.ParseList(_repository.FindAll()); // ParseList deve devolver List<PersonDTO>
    }

    public PersonDTO FindById(long id)
    {
        return _converter.Parse(_repository.FindById(id)); // Parse(Person) -> PersonDTO
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = _converter.Parse(person); // Parse(PersonDTO) -> Person
        entity = _repository.Create(entity);
        return _converter.Parse(entity);
    }

    public PersonDTO Update(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Update(entity);
        return _converter.Parse(entity);
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}