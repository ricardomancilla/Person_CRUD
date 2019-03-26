using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public Person GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Person Insert(Person entity)
        {
            var currentPerson = GetAll().Where(p => p.Email.Equals(entity.Email)).FirstOrDefault();
            if (currentPerson == null)
            {
                var result = _repository.Insert(entity);
                _repository.SaveChanges();
                return result;
            }
            return null;
        }

        public Person Update(Person entity)
        {
            var currentPerson = GetAll().Where(p => p.Email.Equals(entity.Email) && !p.Id.Equals(entity.Id)).FirstOrDefault();
            if (currentPerson == null)
            {
                _repository.Update(entity);
                _repository.SaveChanges();
                return GetById(entity.Id);
            }
            return null;
        }

        public bool Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
            return true;
        }
    }
}
