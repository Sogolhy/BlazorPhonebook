using Contact.Entities;
using Contact.Entities.ViewModel;
using Contact.Repositories;
using Contact.Repository.Context;
using Contact.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contact.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public ResultMessage Delete(int id)
        {
            var objFromDb = personRepository.Get(id);
            if (objFromDb == null)
            {
                return new ResultMessage() { Success = false, Message = "Error while deleting" };

            }
            personRepository.Remove(objFromDb);

            return new ResultMessage() { Success = true, Message = "Delete Successful" };

        }
        public List <PersonViewModel> GetAll()
        {
            //  return NotFound();
            IEnumerable<Entities.Person> allperson = personRepository.GetAll(includeProperties: "PhoneNumbers");
            //var mgskjd = allperson.Select(i => new PersonViewModel()
            //{
            //    Family = i.Family,
            //    Name = i.Name,
            //    Id = i.Id,
            //    PhoneNumber = string.Join(",", i.PhoneNumbers.Select(j => j.Phone).ToList())
            //});
            List<PersonViewModel> result = allperson.SelectMany(i => i.PhoneNumbers
                .Select(j=>new PersonViewModel() {
                    Family = i.Family,
                    Name = i.Name,
                    Id = i.Id,
                    PhoneNumber=j.Phone
                })).ToList();
            return result;

        }

        public string AddPerson(PersonViewModel personViewModel)
        {
           Person person= personRepository.Add(new Person()
            {
                Family = personViewModel.Family,
                Name = personViewModel.Name
            });
            string TextMessage;
            if (person != null)
            {
                TextMessage = "Add Person success";
                
            }
            else
                TextMessage = "Add Person  not success";
            return TextMessage;
        }

    }
}
