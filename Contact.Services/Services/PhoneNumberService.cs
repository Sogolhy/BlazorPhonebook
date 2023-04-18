using Contact.Entities;
using Contact.Entities.ViewModel;
using Contact.Repositories;
using Contact.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Services.Services
{
    public class PhoneNumberService : IPhoneNumberService
    {
        private readonly IPhoneNumbersRepository phoneNumberRepository;
        public PhoneNumberService(IPhoneNumbersRepository phoneNumberRepository)
        {
            this.phoneNumberRepository = phoneNumberRepository;
        }
        public List<PersonViewModel> GetAll()
        {

            IEnumerable<Entities.PhoneNumber> allphoneNumber = phoneNumberRepository.GetAll(includeProperties: nameof(Person));

            List<PersonViewModel> result = allphoneNumber.Select(i =>new  PersonViewModel()
            {
               Family = i.Person.Family,
               Name = i.Person.Name,
               Id = i.Person.Id,
               PhoneNumber = i.Phone
            }
            ).ToList();
            
            return result;

        }
    }
}
