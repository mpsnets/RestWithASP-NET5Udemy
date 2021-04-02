using Person.Model;
using System.Collections.Generic;

namespace Person.Repository
{
    public interface IBookRepository
    {
        Model.Book Create(Model.Book book);
        Model.Book Update(Model.Book book);
        Model.Book FindById(long id);
        List<Model.Book> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
