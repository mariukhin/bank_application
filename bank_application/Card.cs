using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_application
{
    public class Card
    {
		public string CardNumber { get; set; }
		public string CardName { get; set; }
		public int PIN { get; set; }
		public int CVcode { get; set; }
		public string Term { get; set; }
		public int Money { get; set; }


		//public Client Client
		//{
		//	get
		//	{

		//	}
		//}
		public Card(string CardNumber,string CardName, Client Client, int PIN, int CVcode, string Term, int Money)
		{
			this.CardNumber = CardNumber;
			this.CardName = CardName;
			this.PIN = PIN;
			this.CVcode = CVcode;
			this.Term = Term;
			this.Money = Money;
			//this.Client = Client;
		}
	}
}
