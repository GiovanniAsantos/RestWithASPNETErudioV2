using RestWithASPNET10Erudio.Rest.Data.Converter.Impl;
using RestWithASPNET10Erudio.Rest.Data.DTO.V2;
using RestWithASPNET10Erudio.Rest.Model;
using RestWithASPNET10Erudio.Rest.Repositories;

namespace RestWithASPNET10Erudio.Rest.Services.Impl.V2;

public class PersonImplV2
{
    private IRepository<Person> _repository;
    private readonly PersonConverter _converter;

    public PersonImplV2(IRepository<Person> repository)
    {
        _repository = repository;
        _converter = new PersonConverter();
    }

    public PersonDTO Create(PersonDTO person)
    {
        var entity = _converter.Parse(person);
        entity = _repository.Create(entity);
        return _converter.Parse(entity);
    }
}