using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IPersonService
    {
        List<Person> GetAll();

        Person GetById(int id);

        Person Insert(Person entity);

        Person Update(Person entity);

        bool Delete(int id);
    }
}
