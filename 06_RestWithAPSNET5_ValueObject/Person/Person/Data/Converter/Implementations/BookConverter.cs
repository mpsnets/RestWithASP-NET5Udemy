using Person.Data.Converter.Contract;
using Person.Data.VO;
using Person.Model;
using System.Collections.Generic;
using System.Linq;

namespace Person.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                Title = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                Title = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(p => Parse(p)).ToList();
        }
        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(p => Parse(p)).ToList();
        }
    }
}
