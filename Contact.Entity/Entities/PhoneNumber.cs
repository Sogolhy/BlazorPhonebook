using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contact.Entities
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }

        public string Phone { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }

}
