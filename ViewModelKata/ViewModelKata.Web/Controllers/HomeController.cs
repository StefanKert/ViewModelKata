using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ViewModelKata.Web.Controllers
{
    public class HomeController : ApiController
    {
        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("~/")]
        public HttpResponseMessage Get()
        {
            var page = System.IO.File.ReadAllText(HttpRuntime.AppDomainAppPath + @"index.html");

            var content = new StringContent(page, Encoding.ASCII);
            content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return new HttpResponseMessage { Content = content };
        }
    }
}
