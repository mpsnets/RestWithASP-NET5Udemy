using System.ComponentModel.DataAnnotations.Schema;

namespace Person.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
