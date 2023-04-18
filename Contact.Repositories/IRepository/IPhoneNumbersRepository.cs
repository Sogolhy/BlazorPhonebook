using Contact.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Repositories
{
    public interface IPhoneNumbersRepository : IRepository<PhoneNumber>
    {
        void Update(PhoneNumber phoneNumbers);
    }
}
