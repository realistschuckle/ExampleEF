using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleEF
{
    [Table("Employee", Schema="HumanResources")]
    public class Employee : Person
    {
        public string LoginID { get; set; }

        public string JobTitle { get; set; }

        public DateTime HireDate { get; set; }

        public short VacationHours { get; set; }

        [Column("CurrentFlag")]
        public bool IsCurrent { get; set; }
    }
}
