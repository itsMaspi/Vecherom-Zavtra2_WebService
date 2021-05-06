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
		#region Users
		// PUT: api/users !!!!! [DEPRECATED] !!!!!
		[HttpPut]
        [Route("api/users/{username}/{password}")]
        public HttpResponseMessage Signup(string username, string password)
        {
            Repository r = new Repository();
            Response responseMessage = r.Signup(username, password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            return response;
        }
        // PUT: api/users
        [HttpPut]
        [Route("api/users")]
        public HttpResponseMessage Signup([FromBody] LoginUser user)
        {
            Repository r = new Repository();
            Response responseMessage = r.Signup(user.username, user.password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            return response;
        }

        // GET: api/users !!!!! [DEPRECATED] !!!!!
        [HttpGet]
        [Route("api/users/{username}/{password}")]
        public HttpResponseMessage Login(string username, string password)
        {
            Repository r = new Repository();
            Response responseMessage = r.Login(username, password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            return response;
        }
        // GET: api/users
        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage Login([FromBody] LoginUser user)
        {
            Repository r = new Repository();
            Response responseMessage = r.Login(user.username, user.password);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            return response;
        }

        // DELETE: api/users !!!!! [DEPRECATED] !!!!!
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
        // DELETE: api/users
        [HttpDelete]
        [Route("api/users")]
        public HttpResponseMessage RemoveAccount([FromBody] LoginUser user)
        {
            Repository r = new Repository();
            bool resp = false;
            Response loginResponse = r.Login(user.username, user.password);
            if (loginResponse != null && loginResponse.Message.Equals("User successfully logged in"))
            {
                r.RemoveAccount(loginResponse.UserID);
                resp = true;
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, resp);
            return response;
        }
        #endregion
        #region UserCfg
        // GET: api/usercfg
        [HttpPost]
        [Route("api/usercfg")]
        public HttpResponseMessage GetUserConfig([FromBody] UserCfgRequest userCfg)
        {
            Repository r = new Repository();
            string responseMessage = r.GetUserCfg(userCfg.UserID);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            return response;
        }

        // PUT: api/usercfg
        [HttpPut]
        [Route("api/usercfg")]
        public HttpResponseMessage UpdateUserConfig([FromBody] UserCfgRequest userCfg)
        {
            Repository r = new Repository();
            bool responseMessage = r.UpdateUserCfg(userCfg.UserID, userCfg.Config);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, responseMessage);
            return response;
        }
        #endregion
    }
}