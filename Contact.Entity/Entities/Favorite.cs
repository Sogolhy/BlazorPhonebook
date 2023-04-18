using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contact.Entities
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

   
       

 

    }
}
