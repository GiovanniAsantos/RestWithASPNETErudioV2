using RestWithASPNET10Erudio.Rest.Data.DTO.V1;

namespace RestWithASPNET10Erudio.Rest.Services;

public interface IBookService
{
    BookDTO Create(BookDTO book);
    
    BookDTO FindById(long id);
    
    List<BookDTO> FindAll();
    
    BookDTO Update(BookDTO book);
    
    void Delete(long id);
}