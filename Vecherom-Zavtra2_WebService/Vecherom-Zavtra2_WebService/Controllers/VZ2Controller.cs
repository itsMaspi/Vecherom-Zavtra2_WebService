using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Vecherom_Zavtra2_WebService.Models;

namespace Vecherom_Zavtra2_WebService.Controllers
{
    public class VZ2Controller : ApiController
    {
        // PUT: api/users
        [HttpPut]
        [Route("api/users/{username}/{password}")]
        public HttpResponseMessage Signup(string username, string password)
        {
            Repository r = new Repository();
            Response responseMessage = r.Signup(username, password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            return response;
        }

        // GET: api/users
        [HttpGet]
        [Route("api/users/{username}/{password}")]
        public HttpResponseMessage Login(string username, string password)
        {
            Repository r = new Repository();
            Response responseMessage = r.Login(username, password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            return response;
        }

        // DELETE: api/users
        [HttpDelete]
        [Route("api/users/{username}/{password}")]
        public HttpResponseMessage RemoveAccount(string username, string password)
        {
            Repository r = new Repository();
            bool resp = false;
            Response loginResponse = r.Login(username, password);
            if (loginResponse != null && loginResponse.Message.Equals("User successfully logged in"))
			{
                r.RemoveAccount(loginResponse.UserID);
                resp = true;
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, resp);
            return response;
        }
    }
}