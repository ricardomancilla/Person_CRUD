using System.Net;
using System.Web.Http;

namespace API.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult Result(HttpStatusCode statusCodeResult, object content)
        {
            switch (statusCodeResult)
            {
                case (HttpStatusCode.OK):
                case (HttpStatusCode.Created):
                    return Content(statusCodeResult, content);
                case (HttpStatusCode.NoContent):
                case (HttpStatusCode.NotFound):
                    return StatusCode(statusCodeResult);
                case (HttpStatusCode.BadRequest):
                case (HttpStatusCode.Forbidden):
                case (HttpStatusCode.Conflict):
                case (HttpStatusCode.InternalServerError):
                    return Content(statusCodeResult, content.ToString());
                default:
                    return Ok();
            }
        }
    }
}
