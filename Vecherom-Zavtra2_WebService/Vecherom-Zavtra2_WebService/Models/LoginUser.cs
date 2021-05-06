using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vecherom_Zavtra2_WebService.Models
{
	public class LoginUser
	{
		public string username { get; set; }
		public string password { get; set; }

		public LoginUser()
		{

		}
		public LoginUser(string username, string password)
		{
			this.username = username;
			this.password = password;
		}
	}
}