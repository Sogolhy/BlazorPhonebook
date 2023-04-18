using Contact.Entities.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Services.IServices
{
    public  interface IPersonService
    {
        public ResultMessage Delete (int id);
        public List <PersonViewModel> GetAll();
        public string AddPerson (PersonViewModel person);
        
    }
}
