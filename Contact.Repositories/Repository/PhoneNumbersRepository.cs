using Contact.Entities;
using Contact.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contact.Repositories
{
    public class PhoneNumbersRepository : Repository<PhoneNumber>, IPhoneNumbersRepository
    {
        private readonly SqlDbContext _db;
        public PhoneNumbersRepository(SqlDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PhoneNumber phoneNumbers)
        {
           
              
                var objFromDb = _db.PhoneNumbers.FirstOrDefault(s=>s.Id == phoneNumbers.Id);
            if(objFromDb!=null)
            { 
                objFromDb.Phone = phoneNumbers.Phone;

                
            }
        }

 
    }
}
