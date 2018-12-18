using System.ComponentModel;
using System.Runtime.CompilerServices;
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
		public void CheckTransaction(Card senderCard, string giveCard, int summ)
		{
			Card CardGive = new Card();
			CardGive = CheckGiveCard(giveCard);
			UpdateCards(senderCard, CardGive, summ);
			OpenConnection();
			SqlCmd.CommandText = "INSERT INTO transactions ('sendercard', 'givecard','sum') values ('" +
						senderCard.CardNumber + "' , '" + CardGive.CardNumber + "' , '" + summ + "')";
			SqlCmd.ExecuteNonQuery();
			CloseConnection();
		}
		public static void TopUpMobile(Card senderCard, int sum)
		{
			int senderMoney = senderCard.Money - sum;
			senderCard.UpdateCardMoney(senderCard, senderMoney);
		}
		private static void UpdateCards(Card cardSend, Card cardGive, int sum)
		{
			int senderMoney = cardSend.Money - sum;
			int giveMoney = cardGive.Money + sum;
			double cashback = sum * 0.005;
			cardSend.UpdateCardMoney(cardSend, senderMoney);
			cardGive.UpdateCardMoney(cardGive, giveMoney);

			Client clientSend = new Client(0, "user", "user", "23.02.1003", "VV", 2349959, "dfddd", "dd@kkd.xc", "243320030", "dfdfsd", "dfdf", 0, 0);
			Client clientGive = new Client(0, "user", "user", "23.02.1003", "VV", 2349959, "dfddd", "dd@kkd.xc", "243320030", "dfdfsd", "dfdf", 0, 0);
			clientSend = clientSend.GetClientById(cardSend.ClientId);
			clientGive = clientGive.GetClientById(cardGive.ClientId);
			if (clientSend.Id != clientGive.Id)
			{
				clientSend.UpdateCashback(clientSend, cashback);
			}
		}
		public static bool CheckPayingCapacity(int sendmoney, int cardmoney)
		{
			if (sendmoney <= cardmoney)
			{
				return true;
			}
			return false;
		}
		public static Card CheckGiveCard(string giveCard)
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
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

	}
}
