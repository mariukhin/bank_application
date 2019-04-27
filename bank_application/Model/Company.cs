using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using bank_application.Command;

namespace bank_application.Model
{
	class Company : DBhelperClass, INotifyPropertyChanged
	{
		private ObservableCollection<Credit> credits = new ObservableCollection<Credit>();
		private ObservableCollection<Deposit> deposits = new ObservableCollection<Deposit>();
		private ObservableCollection<Card> cards = new ObservableCollection<Card>();

		private string login;
		public int Id { get; set; }
		private string name;
		private string regnumber;
		private string email;
		private string phonenumber;
		private string adress;
		private string password;


		public Company(int Id, string Name, string RegNumber, string Adress, string Email, string Phonenumber, string Login, string Password)
		{
			this.Id = Id;
			this.Name = Name;
			this.RegNumber = RegNumber;
			this.Adress = Adress;
			this.Email = Email;
			this.Phonenumber = Phonenumber;
			this.Login = Login;
			this.Password = Password;
		}
		
		public void AddNewCompany(Company company)
		{
			OpenConnection();
			SqlCmd.CommandText = "INSERT INTO companies ('name', 'regnumber','adress', 'email','phone', 'login', 'password') values ('" +
					company.Name + "' , '" + company.RegNumber + "' , '" + company.Adress + "', '" +
					company.Email + "', '" + company.Phonenumber + "', '" + company.Login + "', '" +
					company.Password + "', '" + 0 + "', '" + 0 + "')";
			SqlCmd.ExecuteNonQuery();
			CloseConnection();
		}
		
		public Company Auth(Company comp)
		{
			Company newComp = CheckCompany(comp);
			if (newComp != null)
			{
				return newComp;
			}
			else
			{
				return null;
			}
		}
		private Company CheckCompany(Company comp)
		{
			OpenConnection();
			SqlCmd.CommandText = @"SELECT * FROM companies WHERE login = @login and password = @password";
			SqlCmd.Parameters.Add(new SQLiteParameter("@login") { Value = comp.Login });
			SqlCmd.Parameters.Add(new SQLiteParameter("@password") { Value = comp.Password });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
			if (reader.Read())
			{
				comp = new Company(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
					reader.GetString(5), reader.GetString(6), reader.GetString(7));
				reader.Close();
				CloseConnection();
				return comp;
			}
			else
			{
				return null;
			}
		}
		public Company GetCompanyById(int compId)
		{
			OpenConnection();
			SqlCmd.CommandText = @"SELECT * FROM companies WHERE company_id = @companyId";
			SqlCmd.Parameters.Add(new SQLiteParameter("@companyId") { Value = compId });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
			if (reader.Read())
			{
				Company comp = new Company(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
					reader.GetString(5), reader.GetString(6), reader.GetString(7));
				reader.Close();
				CloseConnection();
				return comp;
			}
			else
			{
				return null;
			}
		}
		
		
		//public void UpdateLogin(string data, Client client)
		//{
		//	OpenConnection();
		//	SqlCmd.CommandText = @"UPDATE clients SET login = @login WHERE client_id = @clientid";
		//	SqlCmd.Parameters.Add(new SQLiteParameter("@login") { Value = data });
		//	SqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
		//	SqlCmd.ExecuteNonQuery();
		//	SQLiteDataReader reader;
		//	reader = SqlCmd.ExecuteReader();
		//	reader.Close();
		//	CloseConnection();
		//}
		public ObservableCollection<Card> CreateCards(int clientId)
		{
			OpenConnection();
			SqlCmd.CommandText = @"SELECT * FROM cards WHERE client_id = @clientId and isconfirm = 1";
			SqlCmd.Parameters.Add(new SQLiteParameter("@clientId") { Value = clientId });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
			while (reader.Read())
			{
				Card card = new Card(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3),
					reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8), CheckConfirm(reader.GetInt32(9)));
				Cards.Add(card);
			}
			CloseConnection();
			return Cards;
		}

		public ObservableCollection<Credit> CreateCredits(int clientId)
		{
			OpenConnection();
			SqlCmd.CommandText = @"SELECT * FROM credits WHERE client_id = @clientId and isconfirm = 1";
			SqlCmd.Parameters.Add(new SQLiteParameter("@clientId") { Value = clientId });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
			while (reader.Read())
			{
				Credit credit = new Credit(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
					reader.GetString(3), reader.GetInt32(4), CheckConfirm(reader.GetInt32(5)), Convert.ToDateTime(reader.GetString(6), CultureInfo.CurrentCulture));
				Credits.Add(credit);
			}
			CloseConnection();

			var client = new Service.CountServiceClient("NetTcpBinding_ICountService");

			foreach (Credit credit in Credits)
			{
				int offence = client.CalcCredit(credit.Duration, credit.Number, credit.DateCredit);
				if (offence != 0)
				{
					Card card = new Card(1, credit.CardNumber, "dffdsfwef", 2355, 544, "03.11.2023", "Visa Classic", 0, 2, true);
					card = card.GetCurrentCard(card);
					int newCardMoney = card.Money - offence;
					card.UpdateCardMoney(card, newCardMoney);
				}
			}
			client.Close();
			return Credits;
		}
		public ObservableCollection<Deposit> CreateDeposits(int clientId)
		{
			OpenConnection();
			SqlCmd.CommandText = @"SELECT * FROM deposits WHERE client_id = @clientId and isconfirm = 1";
			SqlCmd.Parameters.Add(new SQLiteParameter("@clientId") { Value = clientId });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
			while (reader.Read())
			{
				Deposit deposit = new Deposit(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3),
					reader.GetString(4), reader.GetInt32(5), CheckConfirm(reader.GetInt32(6)), Convert.ToDateTime(reader.GetString(7), CultureInfo.CurrentCulture));
				Deposits.Add(deposit);
			}
			CloseConnection();

			Service.CountServiceClient client = new Service.CountServiceClient("NetTcpBinding_ICountService");
			foreach (Deposit deposit in Deposits)
			{
				double pay = client.CalcDeposit(deposit.Duration, deposit.Number, deposit.DateDeposit);
				if (pay != 0)
				{
					Card card = new Card(1, deposit.CardNumber, "dffdsfwef", 2355, 544, "03.11.2023", "Visa Classic", 0, 2, true);
					card = card.GetCurrentCard(card);
					int newCardMoney = card.Money + (int)pay;
					card.UpdateCardMoney(card, newCardMoney);
				}
			}
			client.Close();
			return Deposits;
			//Credits.Remove(credit);
			//DeleteSelectedItem(credit.Id, "credit");
		}
		public void DeleteSelectedItem(int smthId, string descr)
		{
			OpenConnection();
			if (descr.Contains("credit"))
			{
				SqlCmd.CommandText = @"DELETE FROM credits WHERE credit_id = @smthid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smthId });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (descr.Contains("deposit"))
			{
				SqlCmd.CommandText = @"DELETE FROM deposits WHERE deposit_id = @smthid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smthId });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (descr.Contains("card"))
			{
				SqlCmd.CommandText = @"DELETE FROM cards WHERE card_id = @smthid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smthId });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			CloseConnection();
		}
		public void UpdateInfo(string type, string data, Client client)
		{
			OpenConnection();
			if (type.Contains("name"))
			{
				client.Firstname = data;
				SqlCmd.CommandText = @"UPDATE clients SET first_name = @param WHERE client_id = @clientid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				SqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (type.Contains("regnumber"))
			{
				client.Surname = data;
				SqlCmd.CommandText = @"UPDATE clients SET last_name = @param WHERE client_id = @clientid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				SqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (type.Contains("password"))
			{
				client.Password = data;
				SqlCmd.CommandText = @"UPDATE clients SET password = @param WHERE client_id = @clientid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				SqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (type.Contains("e-mail"))
			{
				client.Email = data;
				SqlCmd.CommandText = @"UPDATE clients SET email = @param WHERE client_id = @clientid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				SqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (type.Contains("phone"))
			{
				client.Phonenumber = data;
				SqlCmd.CommandText = @"UPDATE clients SET phone = @param WHERE client_id = @clientid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@param") { Value = data });
				SqlCmd.Parameters.Add(new SQLiteParameter("@clientid") { Value = client.Id });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
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
		public string Name
		{
			get { return Name; }
			set
			{
				Name = value;
				OnPropertyChanged("Name");
			}
		}
		public string RegNumber
		{
			get { return RegNumber; }
			set
			{
				regnumber = value;
				OnPropertyChanged("RegNumber");
			}
		}
		public string Email
		{
			get { return email; }
			set
			{
				email = value;
				OnPropertyChanged("Email");
			}
		}
		public string Phonenumber
		{
			get { return phonenumber; }
			set
			{
				phonenumber = value;
				OnPropertyChanged("Phonenumber");
			}
		}
		public string Adress
		{
			get { return adress; }
			set
			{
				adress = value;
				OnPropertyChanged("Adress");
			}
		}
		public string Password
		{
			get { return password; }
			set
			{
				password = value;
				OnPropertyChanged("Password");
			}
		}
		public ObservableCollection<Credit> Credits => credits;
		public void SetCredits(ObservableCollection<Credit> value)
		{
			credits = value;
			OnPropertyChanged("Credits");
		}

		public ObservableCollection<Deposit> Deposits => deposits;
		public void SetDeposits(ObservableCollection<Deposit> value)
		{
			deposits = value;
			OnPropertyChanged("Deposits");
		}

		public ObservableCollection<Card> Cards => cards;
		public void SetCards(ObservableCollection<Card> value)
		{
			cards = value;
			OnPropertyChanged("Cards");
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}
		//public override string ToString()
		//{
		//	return Firstname + '|' + Surname + '|' + Password + '|' + Phonenumber + '|' + Email;
		//}
	}
}
