using Domain;
using Domain.Interfaces;
using System;

namespace Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(IDbContext dbContext)
            :base(dbContext)
        {

        }

        public override Person Insert(Person obj)
        {
            obj.CreateDtm = DateTime.Now;
            return base.Insert(obj);
        }
    }
}
