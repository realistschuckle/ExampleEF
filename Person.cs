using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleEF
{
    [Table("Person", Schema="Person")]
    public class Person
    {
        private int id;

        [Column("BusinessEntityID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        // This is just like: public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string MiddleName { get; set; }
    }
}
