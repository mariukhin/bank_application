﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application
{
	public class Request
	{
		public DateTime Date { get; set; }
		public Request(Client client_id, Admin admin_id, Credit credit_id, Deposit deposit_id, Card card_id, DateTime Date)
		{
			this.Date = Date;
		}
		//public override string ToString()
		//{
		//	return client_id+;
		//}
	}
}
