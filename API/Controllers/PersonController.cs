using Domain;
using Domain.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class PersonController : BaseApiController
    {
        IPersonService _personRepository;

        public PersonController(IPersonService personRepository)
        {
            _personRepository = personRepository;
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> GetAll()
        {
            return Result(System.Net.HttpStatusCode.OK, await Task.FromResult(_personRepository.GetAll()));
        }

        [ActionName("Get")]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Result(System.Net.HttpStatusCode.OK, await Task.FromResult(_personRepository.GetById(id)));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(Person entity)
        {
            if (!ModelState.IsValid)
                return Result(System.Net.HttpStatusCode.BadRequest, "Invalid data.");
            var result = await Task.FromResult(_personRepository.Insert(entity));
            if(result != null)
                return Result(System.Net.HttpStatusCode.Created, result);
            return Result(System.Net.HttpStatusCode.BadRequest, "Already exists a person with the email provided.");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(Person entity)
        {
            if (!ModelState.IsValid)
                return Result(System.Net.HttpStatusCode.BadRequest, "Invalid data.");

            var currentPerson = _personRepository.GetById(entity.Id);
            currentPerson.FirstName = entity.FirstName;
            currentPerson.LastName = entity.LastName;
            currentPerson.Email = entity.Email;

            var result = await Task.FromResult(_personRepository.Update(currentPerson));
            if (result != null)
                return Result(System.Net.HttpStatusCode.NoContent, result);
            return Result(System.Net.HttpStatusCode.BadRequest, "Already exists a person with the email provided.");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Result(System.Net.HttpStatusCode.NoContent, await Task.FromResult(_personRepository.Delete(id)));
        }
    }
}
