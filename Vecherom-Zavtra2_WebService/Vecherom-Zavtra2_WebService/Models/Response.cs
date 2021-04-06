using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vecherom_Zavtra2_WebService.Models
{
	public class Response
	{
		public string Message { get; set; }
		public int UserID { get; set; }

		public Response(string Message, int UserID)
		{
			this.Message = Message;
			this.UserID = UserID;
		}
	}
}