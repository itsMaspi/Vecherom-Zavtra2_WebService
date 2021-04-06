using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vecherom_Zavtra2_WebService.Models
{
	public class Repository
	{
		public string Signup(string username, string password)
		{
			System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(string));
			using (var db = new vz2Entities())
			{
				db.procAddUser(username, password, responseMessage);
			}
			return Convert.ToString(responseMessage.Value);
		}

		public string Login(string username, string password)
		{
			System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(string));
			using (var db = new vz2Entities())
			{
				db.procLogin(username, password, responseMessage);
			}
			return Convert.ToString(responseMessage.Value);
		}

		public bool RemoveAccount(string username, string password)
		{
			System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(string));
			using (var db = new vz2Entities())
			{
				db.Users.Remove()
			}
			return Convert.ToString(responseMessage.Value);
		}
	}
}