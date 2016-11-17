using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleEF
{
    [Table("Currency", Schema="Sales")]
    public class Currency
    {
        public Currency()
        {
            ModifiedDate = DateTime.Now;
        }

        [Key]
        [Column("CurrencyCode")]
        public string Code { get; set; }

        public string Name { get; set; }
        
        public DateTime ModifiedDate { get; set; }
    }
}
