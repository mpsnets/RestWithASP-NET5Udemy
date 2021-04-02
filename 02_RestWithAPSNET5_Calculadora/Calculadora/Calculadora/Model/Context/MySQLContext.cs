using Microsoft.EntityFrameworkCore;

namespace Calculator.Model.Context
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
    }
}
