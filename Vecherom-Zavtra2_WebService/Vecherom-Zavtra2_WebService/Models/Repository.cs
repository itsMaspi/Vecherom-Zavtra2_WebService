using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vecherom_Zavtra2_WebService.Models
{
	public class Repository
	{
		public Response Signup(string username, string password)
		{
			System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(string));
			using (var db = new vz2Entities())
			{
				db.procAddUser(username, password, responseMessage);
			}
			return new Response(Convert.ToString(responseMessage.Value), -1);
		}

		public Response Login(string username, string password)
		{
			System.Data.Entity.Core.Objects.ObjectParameter responseMessage = new System.Data.Entity.Core.Objects.ObjectParameter("responseMessage", typeof(string));
			System.Data.Entity.Core.Objects.ObjectParameter userID = new System.Data.Entity.Core.Objects.ObjectParameter("userID", typeof(int));
			using (var db = new vz2Entities())
			{
				db.procLogin(username, password, responseMessage, userID);
			}
			int uID = -1;
			if (userID.Value != System.DBNull.Value)
			{
				uID = Convert.ToInt32(userID.Value);
			}
			Response r = new Response(Convert.ToString(responseMessage.Value), uID);
			return r;
		}

		public bool RemoveAccount(int userID)
		{
			using (var db = new vz2Entities())
			{
				try
				{
					db.Users.Remove(db.Users.Where(x => x.UserId == userID).FirstOrDefault());
					db.SaveChanges();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
				
			}
		}
	}
}