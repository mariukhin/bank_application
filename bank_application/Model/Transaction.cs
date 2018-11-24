using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using System.Data;
using System;
using bank_application.Command;

namespace bank_application
{
	public class Transaction : DBhelperClass, INotifyPropertyChanged
	{
		public int Id { get; set; }
		private string clientsendercard;
		private string clientgivecard;
		private int sum;

		public Transaction(int Id,string ClientSenderCard, string ClientGiveCard, int Sum)
		{
			this.Id = Id;
			this.ClientSenderCard = ClientSenderCard;
			this.ClientGiveCard = ClientGiveCard;
			this.Sum = Sum;
		}
		public void CheckTransaction(Card senderCard, string giveCard, int sum)
		{
			Card CardGive = new Card();
			CardGive = CheckGiveCard(giveCard);
			UpdateCards(senderCard, CardGive, sum);
			OpenConnection();
			m_sqlCmd.CommandText = "INSERT INTO transactions ('sendercard', 'givecard','sum') values ('" +
						senderCard.CardNumber + "' , '" + CardGive.CardNumber + "' , '" + sum + "')";
			m_sqlCmd.ExecuteNonQuery();
			CloseConnection();
		}
		private void UpdateCards(Card cardSend, Card cardGive, int sum)
		{
			int senderMoney = cardSend.Money - sum;
			int giveMoney = cardGive.Money + sum;
			double cashback = sum * 0.05;
			cardSend.UpdateCardMoney(cardSend, senderMoney);
			cardGive.UpdateCardMoney(cardGive, giveMoney);

			Client client = new Client(0, "user", "user", "23.02.1003", "VV", 2349959, "dfddd", "dd@kkd.xc", "243320030", "dfdfsd", "dfdf", 0, 0);
			client = client.GetClientById(cardSend.ClientId);
			client.UpdateCashback(client ,cashback);
		}
		public bool CheckPayingCapacity(int sendmoney, int cardmoney)
		{
			if (sendmoney <= cardmoney)
			{
				return true;
			}
			return false;
		}
		public Card CheckGiveCard(string giveCard)
		{
			Card gcard = new Card(giveCard);
			if (gcard.GetCurrentCard(gcard) != null)
			{
				gcard = gcard.GetCurrentCard(gcard);
				return gcard;
			}
			else
			{
				return null;
			}
		}
		public string ClientSenderCard
		{
			get { return clientsendercard; }
			set
			{
				clientsendercard = value;
				OnPropertyChanged("ClientSenderCard");
			}
		}
		public string ClientGiveCard
		{
			get { return clientgivecard; }
			set
			{
				clientgivecard = value;
				OnPropertyChanged("ClientGiveCard");
			}
		}
		public int Sum
		{
			get { return sum; }
			set
			{
				sum = value;
				OnPropertyChanged("Sum");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

	}
}
