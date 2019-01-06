using NShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TShop.Web.infrastructure.Core;

namespace TShop.Web.Api
{
    [RoutePrefix("api/Home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IErrorService _errorService;
        public HomeController(IErrorService ierrorSerivce):base(ierrorSerivce)
        {
            this._errorService = ierrorSerivce;
        }
        [HttpGet]
        [Route("TestMethod")]
        public string TestMethod()
        {
            return "Hello, C# Corner Member";
        }
    }
}
