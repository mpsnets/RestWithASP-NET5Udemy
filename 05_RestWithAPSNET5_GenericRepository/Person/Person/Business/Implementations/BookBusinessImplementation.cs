using Person.Model;
using Person.Repository;
using System.Collections.Generic;


namespace Person.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {

        private readonly IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
        }


        public Model.Book Create(Model.Book book)
        {
            return _repository.Create(book);
        }

        public Model.Book Update(Model.Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Model.Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Model.Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public bool Exists(long id)
        {
            return _repository.Exists(id);
        }
    }
}
