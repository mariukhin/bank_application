using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application
{
    public class Credit
    {
		public int Duration { get; set; }
		public int Number { get; set; }

		//public Guid _clientId;
		//public Client Client
		//{
		//	get
		//	{
		//		try
		//		{
		//			return Client.data[_clientId];
		//		}
		//		catch (Exception) { }
		//		return null;

		//	}
		//	set { _clientId = value.ID; }
		//}

		public Credit(Client Client, int Duration, int Number)
		{
			//this.Client = Client;
			this.Duration = Duration;
			this.Number = Number;
		}
	}
}
