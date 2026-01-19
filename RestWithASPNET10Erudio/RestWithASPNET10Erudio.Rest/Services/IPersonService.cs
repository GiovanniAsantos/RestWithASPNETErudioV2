
using RestWithASPNET10Erudio.Rest.Data.DTO.V2;

namespace RestWithASPNET10Erudio.Rest.Services;

public interface IPersonService
{
    PersonDTO Create(PersonDTO person);
    
    PersonDTO FindById(long id);
    
    List<PersonDTO> FindAll();
    
    PersonDTO Update(PersonDTO person);
    
    void Delete(long id);
}