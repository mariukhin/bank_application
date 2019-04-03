using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using bank_application.Command;

namespace bank_application
{
    public class Card: DBhelperClass, INotifyPropertyChanged
	{
		public int Id { get; set; }
		private string cardnumber;
		private string cardname;
		private int pin;
		private int cvcode;
		private string cardtype;
		private string term;
		private int money;
		private int clientid;
		private bool isconfirmcard;
		private Context context;

		public Card(int Id, string CardNumber,string CardName, int PIN, int CVcode, string Term, string CardType, int Money, int ClientId, bool IsConfirmCard)
		{
			this.Id = Id;
			this.CardNumber = CardNumber;
			this.CardName = CardName;
			this.PIN = PIN;
			this.CVcode = CVcode;
			this.CardType = CardType;
			this.Term = Term;
			this.Money = Money;
			this.ClientId = ClientId;
			this.IsConfirmCard = IsConfirmCard;
		}
		public Card() {}
		public Card(string CardNumber)
		{
			this.CardNumber = CardNumber;
		}

		public void AddNewCard(Card card, int numberOfAlgorythm)
		{
			context = new Context();
			if (numberOfAlgorythm == 1)
			{
				context.SetGenerator(new FirstAlgorythm());
			}
			else
			{
				context.SetGenerator(new SecondAlgorythm());
			}
			card.CardNumber = context.DoSomeBusinessLogic();
			card.CVcode = GenerateCVcode();
			OpenConnection();
			SqlCmd.CommandText = "INSERT INTO cards ('cardnumber', 'cardname','pin','cvcode','term', 'cardtype','money','client_id') values ('" +
						card.CardNumber + "' , '" + card.CardName + "' , '" + card.PIN + "' , '" + card.CVcode + "' , '" +
						card.Term + "' , '" + card.CardType + "' , '" + card.Money + "' , '" + card.ClientId + "')";
			SqlCmd.ExecuteNonQuery();
			CloseConnection();
			//DateTime dt = new DateTime();
			//card.Term = GenerateTerm(dt);
		}
		public void DeleteSelectedCard(int cardId)
		{
			OpenConnection();
			SqlCmd.CommandText = @"DELETE FROM cards WHERE card_id = @smthid";
			SqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = cardId });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader = SqlCmd.ExecuteReader();
			CloseConnection();
		}
		public Card GetCurrentCard(Card card)
		{
			OpenConnection();
			SqlCmd.CommandText = @"SELECT * FROM cards WHERE cardnumber = @cardnumber";
			SqlCmd.Parameters.Add(new SQLiteParameter("@cardnumber") { Value = card.CardNumber });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();

			if (reader.Read())
			{
				card = new Card(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3),
					reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8), CheckConfirm(reader.GetInt32(9)));
				reader.Close();
				CloseConnection();
				return card;
			}
			else
			{
				return null;
			}
		}
		public void UpdateCardMoney(Card card, int moneyg)
		{
			OpenConnection();
			SqlCmd.CommandText = @"UPDATE cards SET money = @money WHERE card_id = @cardid";
			SqlCmd.Parameters.Add(new SQLiteParameter("@money") { Value = moneyg });
			SqlCmd.Parameters.Add(new SQLiteParameter("@cardid") { Value = card.Id });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
			reader.Close();
			CloseConnection();
		}
		private static int GenerateCVcode()
		{
			Random rand = new Random();
			int res = rand.Next(999);
			return res;
		}
		

		public string CardNumber
		{
			get { return cardnumber; }
			set
			{
				cardnumber = value;
				OnPropertyChanged("CardNumber");
			}
		}
		public string CardName
		{
			get { return cardname; }
			set
			{
				cardname = value;
				OnPropertyChanged("CardName");
			}
		}
		public int PIN
		{
			get { return pin; }
			set
			{
				pin = value;
				OnPropertyChanged("PIN");
			}
		}
		public int CVcode
		{
			get { return cvcode; }
			set
			{
				cvcode = value;
				OnPropertyChanged("CVcode");
			}
		}
		public string CardType
		{
			get { return cardtype; }
			set
			{
				cardtype = value;
				OnPropertyChanged("CardType");
			}
		}
		public string Term
		{
			get { return term; }
			set
			{
				term = value;
				OnPropertyChanged("Term");
			}
		}
		public int Money
		{
			get { return money; }
			set
			{
				money = value;
				OnPropertyChanged("Money");
			}
		}
		public int ClientId
		{
			get { return clientid; }
			set
			{
				clientid = value;
				OnPropertyChanged("ClientId");
			}
		}
		public bool IsConfirmCard
		{
			get { return isconfirmcard; }
			set
			{
				isconfirmcard = value;
				OnPropertyChanged("IsConfirmCard");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
