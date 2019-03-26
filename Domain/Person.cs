using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("PERSON")]
    public class Person
    {
        public Person()
        {
            CreateDtm = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(20), Required]
        public string FirstName { get; set; }

        [MaxLength(20), Required]
        public string LastName { get; set; }

        [MaxLength(50), DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }

        public DateTime CreateDtm { get; set; }
    }
}
