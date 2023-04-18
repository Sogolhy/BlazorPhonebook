
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using Contact.Entities;
using Contact.Repository.Context;

namespace Contact.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly SqlDbContext _db;
        public PersonRepository(SqlDbContext db) : base(db)
        {
            _db = db;
        }

       
        public void Update(Person person)
        {
           
                var objFromDb = _db.Persons.FirstOrDefault(s=>s.Id == person.Id);
            if(objFromDb!=null)
            { 
                objFromDb.Name = person.Name;
                objFromDb.Family = person.Family;
                //objFromDb.PhoneNumbersId = person.PhoneNumbersId;

            }
        }

 
 
    }
}
