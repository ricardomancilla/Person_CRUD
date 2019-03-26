using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        public string API_URL = ConfigurationManager.AppSettings["API_URL"];

        public ByteArrayContent GetHttpContent(object model)
        {
            var content = JsonConvert.SerializeObject(model);
            return new StringContent(content, Encoding.UTF8, "application/json");
        }
    }
}