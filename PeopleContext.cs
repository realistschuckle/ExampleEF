using System.Data.Entity;

namespace ExampleEF
{
    public class PeopleContext : DbContext
    {
        public PeopleContext()
            : base("PersonContextUm")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }
    }
}
