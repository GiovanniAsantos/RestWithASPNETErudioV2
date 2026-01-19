using Mapster;
using RestWithASPNET10Erudio.Rest.Data.DTO.V1;
using RestWithASPNET10Erudio.Rest.Model;
using RestWithASPNET10Erudio.Rest.Repositories;

namespace RestWithASPNET10Erudio.Rest.Services.Impl.V1;

public class BookImpl : IBookService
{
    private IRepository<Book> _repository;

    public BookImpl(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public List<BookDTO> FindAll()
    {
        return _repository.FindAll().Adapt<List<BookDTO>>(); 
    }

    public BookDTO FindById(long id)
    {
        return _repository.FindById(id).Adapt<BookDTO>();
    }

    public BookDTO Create(BookDTO book)
    {
        var entity = book.Adapt<Book>();
        entity = _repository.Create(entity);
        return entity.Adapt<BookDTO>();
    }

    public BookDTO Update(BookDTO book)
    {
        var entity = book.Adapt<Book>();
        entity = _repository.Update(entity);
        return entity.Adapt<BookDTO>();
    }

    public void Delete(long id)
    {
        _repository.Delete(id);
    }
}