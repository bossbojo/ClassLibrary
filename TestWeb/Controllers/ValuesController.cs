using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWeb.Authen;
namespace TestWeb.Controllers
{
    public class ValuesController : ApiController
    {
        [Route("api/auth")]
        public string Get_AuthSET()
        {
            return AuthTest.Auth.SetAuthenticated(new Authen.User
            {
                fisrtname = "paramat",
                lastname = "singkon"
            });
        }
        [Route("api/get/auth")]
        public IHttpActionResult GetAuth(string token)
        {
            return Json(AuthTest.Auth.GetAuthenticated(token));
        }
        // GET api/values
        [JWTAuthorize]
        public IHttpActionResult Get()
        {
            return Json(AuthTest.Auth.auth_User.User);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
