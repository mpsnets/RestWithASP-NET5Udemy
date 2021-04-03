using Person.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Person.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public System.DateTime LaunchDate { get; set; }
        public double Price { get; set; }
    }
}
