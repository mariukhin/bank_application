using System.Data.SQLite;
using System.Collections.ObjectModel;
using System;
using bank_application.CountService;


namespace bank_application
{
    public class Client : User
	{
		private ObservableCollection<Credit> credits = new ObservableCollection<Credit>();
		private ObservableCollection<Deposit> deposits = new ObservableCollection<Deposit>();
		private ObservableCollection<Card> cards = new ObservableCollection<Card>();

		private string login;
		private double cashback;
		private double moneybox;

		public Client(int Id,string Firstname, string Surname, string DateOfBirth, string PassportSeries, int PassportNum,
			string Adress, string Email, string Phonenumber, string Login, string Password, double Cashback, double Moneybox) : base(Id, Firstname, Surname, DateOfBirth, PassportSeries, PassportNum, Adress, Email, Phonenumber, Password)
		{
			this.Id = Id;
			this.Firstname = Firstname;
			this.Surname = Surname;
			this.DateOfBirth = DateOfBirth;
			this.PassportSeries = PassportSeries;
			this.PassportNum = PassportNum;
			this.Adress = Adress;
			this.Email = Email;
			this.Phonenumber = Phonenumber;
			this.Login = Login;
			this.Password = Password;
			this.Cashback = Cashback;
			this.Moneybox = Moneybox;
		}
		public void AddNewClient(Client client)
		{
			OpenConnection();
			m_sqlCmd.CommandText = "INSERT INTO clients ('first_name', 'last_name', 'dateofbirth', " +
					"'passportseries', 'passportnum', 'adress', 'email','phone', 'login', 'password', 'cashback','moneybox') values ('" +
					client.Firstname + "' , '" + client.Surname + "' , '" + client.DateOfBirth + "', '" +
					client.PassportSeries + "', '" + client.PassportNum + "', '" + client.Adress + "', '" +
					client.Email + "', '" + client.Phonenumber + "', '" + client.Login + "', '" +
					client.Password + "', '" + 0 + "', '" + 0 + "')";
			m_sqlCmd.ExecuteNonQuery();
			CloseConnection();
		}
		public Client AuthClient(Client client)
		{
			Client newClient = CheckClient(client);
			if (newClient != null)
			{
				return newClient;
			}
			else
			{
				return null;
			}
		}
		private Client CheckClient(Client client)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM clients WHERE login = @login and password = @password";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@login") { Value = client.Login });
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@password") { Value = client.Password });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			if (reader.Read())
			{
				client = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
					reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9),
					reader.GetString(10), reader.GetDouble(11), reader.GetInt32(12));
				reader.Close();
				CloseConnection();
				return client;
			}
			else
			{
				return null;
			}
		}
		public Client GetClientById(int clientId)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM clients WHERE client_id = @clientId";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientId") { Value = clientId });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			if (reader.Read())
			{
				Client client = new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
					reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9),
					reader.GetString(10), reader.GetDouble(11), reader.GetInt32(12));
				reader.Close();
				CloseConnection();
				return client;
			}
			else
			{
				return null;
			}
		}
		public void UpdateCashback(Client client, double cashback)
		{
			double newCash;
			if (cashback == 0.0)
			{
				newCash = cashback;
			}
			else
			{
				newCash = client.Cashback + cashback;
			}
			OpenConnection();
			m_sqlCmd.CommandText = @"UPDATE clients SET cashback = @cashback WHERE client_id = @clientid";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@cashback") { Value = newCash });
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			reader.Close();
			CloseConnection();
		}
		public void UpdateMoneyBox(Client client, double moneybox)
		{
			double newCash;
			if (moneybox == 0.0)
			{
				newCash = moneybox;
			}
			else
			{
				newCash = client.Moneybox + moneybox;
			}
			OpenConnection();
			m_sqlCmd.CommandText = @"UPDATE clients SET moneybox = @moneybox WHERE client_id = @clientid";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@moneybox") { Value = newCash });
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			reader.Close();
			CloseConnection();
		}
		public void UpdateLogin(string data, Client client)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"UPDATE clients SET login = @login WHERE client_id = @clientid";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@login") { Value = data });
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			reader.Close();
			CloseConnection();
		}
		public ObservableCollection<Card> CreateCards(int client_id)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM cards WHERE client_id = @clientId and isconfirm = 1";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientId") { Value = client_id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			while (reader.Read())
			{
				Card card = new Card(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3),
					reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7), CheckConfirm(reader.GetInt32(8)));
				Cards.Add(card);
			}
			CloseConnection();
			return Cards;
		}
		
		public ObservableCollection<Credit> CreateCredits(int client_id)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM credits WHERE client_id = @clientId and isconfirm = 1";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientId") { Value = client_id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			while (reader.Read())
			{
				Credit credit = new Credit(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
					reader.GetString(3), reader.GetInt32(4), CheckConfirm(reader.GetInt32(5)), Convert.ToDateTime(reader.GetString(6)));
				Credits.Add(credit);
			}
			CloseConnection();

			CountServiceClient countClient = new CountServiceClient();
			foreach (Credit credit in Credits)
			{
				int offence = countClient.CalcCredit(credit.Duration, credit.Number, credit.DateCredit);
				if (offence != 0)
				{
					Card card = new Card(1, credit.CardNumber, "dffdsfwef", 2355, 544, "03.11.2023", 0, 2, true);
					card = card.GetCurrentCard(card);
					int newCardMoney = card.Money - offence;
					card.UpdateCardMoney(card, newCardMoney);
					Credits.Remove(credit);
					DeleteSelectedItem(credit.Id, "credit");
				}
			}
			countClient.Close();
			return Credits;
		}
		public ObservableCollection<Deposit> CreateDeposits(int client_id)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM deposits WHERE client_id = @clientId and isconfirm = 1";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientId") { Value = client_id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			while (reader.Read())
			{
				Deposit deposit = new Deposit(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3),
					reader.GetString(4), reader.GetInt32(5), CheckConfirm(reader.GetInt32(6)), Convert.ToDateTime(reader.GetString(7)));
				Deposits.Add(deposit);
			}
			CloseConnection();
			CountServiceClient depositClient = new CountServiceClient();
			foreach (Deposit deposit in Deposits)
			{
				double pay = depositClient.CalcDeposit(deposit.Duration, deposit.Number, deposit.DateDeposit);
				if (pay != 0)
				{
					Card card = new Card(1, deposit.CardNumber, "dffdsfwef", 2355, 544, "03.11.2023", 0, 2, true);
					card = card.GetCurrentCard(card);
					int newCardMoney = card.Money + (int)pay;
					card.UpdateCardMoney(card, newCardMoney);
				}
			}
			depositClient.Close();
			return Deposits;
		}
		public void DeleteSelectedItem(int smth_id ,string descr)
		{
			OpenConnection();
			if (descr.Contains("credit"))
			{
				m_sqlCmd.CommandText = @"DELETE FROM credits WHERE credit_id = @smthid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smth_id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (descr.Contains("deposit"))
			{
				m_sqlCmd.CommandText = @"DELETE FROM deposits WHERE deposit_id = @smthid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smth_id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (descr.Contains("card"))
			{
				m_sqlCmd.CommandText = @"DELETE FROM cards WHERE card_id = @smthid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smth_id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			CloseConnection();
		}
		public void UpdateInfo(string type, string data, Client client)
		{
			OpenConnection();
			if (type.Contains("first_name"))
			{
				client.Firstname = data;
				m_sqlCmd.CommandText = @"UPDATE clients SET first_name = @param WHERE client_id = @clientid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value =  client.Id});
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (type.Contains("last_name"))
			{
				client.Surname = data;
				m_sqlCmd.CommandText = @"UPDATE clients SET last_name = @param WHERE client_id = @clientid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (type.Contains("password"))
			{
				client.Password = data;
				m_sqlCmd.CommandText = @"UPDATE clients SET password = @param WHERE client_id = @clientid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (type.Contains("e-mail"))
			{
				client.Email = data;
				m_sqlCmd.CommandText = @"UPDATE clients SET email = @param WHERE client_id = @clientid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (type.Contains("phone"))
			{
				client.Phonenumber = data;
				m_sqlCmd.CommandText = @"UPDATE clients SET phone = @param WHERE client_id = @clientid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}

			CloseConnection();
		}
		public string Login
		{
			get { return login; }
			set
			{
				login = value;
				OnPropertyChanged("Login");
			}
		}
		public double Cashback
		{
			get { return cashback; }
			set
			{
				cashback = value;
				OnPropertyChanged("Cashback");
			}
		}
		public double Moneybox
		{
			get { return moneybox; }
			set
			{
				moneybox = value;
				OnPropertyChanged("Moneybox");
			}
		}
		public ObservableCollection<Credit> Credits
		{
			get { return credits; }
			set
			{
				credits = value;
				OnPropertyChanged("Credits");
			}
		}
		public ObservableCollection<Deposit> Deposits
		{
			get { return deposits; }
			set
			{
				deposits = value;
				OnPropertyChanged("Deposits");
			}
		}
		public ObservableCollection<Card> Cards
		{
			get { return cards; }
			set
			{
				cards = value;
				OnPropertyChanged("Cards");
			}
		}

		public override string ToString()
		{
			return Firstname + '|' + Surname + '|' + Password + '|' + Phonenumber + '|' + Email;
		}
	}
}
