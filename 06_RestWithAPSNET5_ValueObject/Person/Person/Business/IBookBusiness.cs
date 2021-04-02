using Person.Data.VO;
using System.Collections.Generic;

namespace Person.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        void Delete(long id);
        bool Exists(long id);
    }
}
