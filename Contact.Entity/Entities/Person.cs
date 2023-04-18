using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contact.Entities
{
     public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Family { get; set; }
        //[ForeignKey("PhoneNumbersId")]
        //[Required]
        //public int PhoneNumbersId { get; set; }
        public HashSet<PhoneNumber> PhoneNumbers { get; set; }

    }
}
