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
    }
}
