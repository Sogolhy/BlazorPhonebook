using Contact.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Services.IServices
{
    public interface IPhoneNumberService
    {
        public List<PersonViewModel> GetAll();
    }
}
