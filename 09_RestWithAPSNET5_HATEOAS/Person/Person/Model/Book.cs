using Person.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Person.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("launch_date")]
        public System.DateTime LaunchDate { get; set; }

        [Column("price")]
        public double Price { get; set; }
    }
}
