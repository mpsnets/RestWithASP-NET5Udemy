using Microsoft.EntityFrameworkCore;

namespace Person.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
        {

        }

        public DbSet<Person> persons { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
