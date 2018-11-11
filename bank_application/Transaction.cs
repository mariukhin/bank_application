using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application
{
	public class Transaction
	{
		private Client clientSender;
		private Client clientGive;
		private int sum;

		public Transaction(Client clientSender, Client clientGive, int sum)
		{
			this.clientSender = clientSender;
			this.clientGive = clientGive;
			this.sum = sum;
		}
		////private void CountMoney(int )
		////{ }
	}
}
