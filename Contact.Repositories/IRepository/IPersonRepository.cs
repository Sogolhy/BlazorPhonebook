using Contact.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Repositories
{

    public interface IPersonRepository : IRepository<Person>
    {
        void Update(Person person);
    }
}
