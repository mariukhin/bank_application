using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using bank_application.Command;
using System;

namespace bank_application
{
    public class Deposit : DBhelperClass, INotifyPropertyChanged
	{
		public int Id { get; set; }
		private int duration;
		private int number;
		private string cardnumber;
		private string type;
		private int clientid;
		private bool isconfirmdep;
		private Deposit selDeposit;
		private DateTime datedeposit;

		public Deposit(int Id,int Duration, int Number,string CardNumber, string Type, int ClientId, bool IsConfirmDep, DateTime DateDeposit)
		{
			this.Id = Id;
			this.Duration = Duration;
			this.Number = Number;
			this.CardNumber = CardNumber;
			this.Type = Type;
			this.ClientId = ClientId;
			this.IsConfirmDep = IsConfirmDep;
			this.DateDeposit = DateDeposit;
		}
		public bool AddNewDeposit(Deposit deposit , Card card)
		{
			if (CheckPayingCapacity(deposit.Number, card.Money))
			{
				OpenConnection();
				m_sqlCmd.CommandText = "INSERT INTO deposits ('duration', 'number','cardnumber','type', 'client_id', 'date') values ('" +
							deposit.Duration + "' , '" + deposit.Number + "' , '" + deposit.CardNumber + "' , '" + deposit.Type +
							"' , '" + deposit.ClientId + "' , '" + deposit.DateDeposit + "')";
				m_sqlCmd.ExecuteNonQuery();
				CloseConnection();
				return true;
			}
			return false;
		}
		private bool CheckPayingCapacity(int depositmoney, int cardmoney)
		{
			if (depositmoney <= cardmoney)
			{
				return true;
			}
			return false;
		}
		public Deposit GetCurrentDeposit(Deposit deposit)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM deposits WHERE duration = @duration and number = @number 
				and type = @type and client_id = @client_Id";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@duration") { Value = deposit.Duration });
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@number") { Value = deposit.Number });
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@type") { Value = deposit.Type });
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@client_Id") { Value = deposit.ClientId });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();

			if (reader.Read())
			{
				deposit = new Deposit(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),reader.GetString(3),
					reader.GetString(4), reader.GetInt32(5), CheckConfirm(reader.GetInt32(6)), Convert.ToDateTime(reader.GetString(7)));
				reader.Close();
				CloseConnection();
				return deposit;
			}
			else
			{
				return null;
			}
		}
		public void DeleteSelectedDeposit(int deposit_id)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"DELETE FROM deposits WHERE deposit_id = @smthid";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = deposit_id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			CloseConnection();
		}
		public int Duration
		{
			get { return duration; }
			set
			{
				duration = value;
				OnPropertyChanged("Duration");
			}
		}
		public int Number
		{
			get { return number; }
			set
			{
				number = value;
				OnPropertyChanged("Number");
			}
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
		public string Type
		{
			get { return type; }
			set
			{
				type = value;
				OnPropertyChanged("Type");
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
		public bool IsConfirmDep
		{
			get { return isconfirmdep; }
			set
			{
				isconfirmdep = value;
				OnPropertyChanged("IsConfirmDep");
			}
		}
		public Deposit SelectedDeposit
		{
			get { return selDeposit; }
			set
			{
				selDeposit = value;
				OnPropertyChanged("SelectedDeposit");
			}
		}
		public DateTime DateDeposit
		{
			get { return datedeposit; }
			set
			{
				datedeposit = value;
				OnPropertyChanged("DateDeposit");
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
