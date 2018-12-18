using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using bank_application.Command;
using System;
using System.Globalization;

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
				SqlCmd.CommandText = "INSERT INTO deposits ('duration', 'number','cardnumber','type', 'client_id', 'date') values ('" +
							deposit.Duration + "' , '" + deposit.Number + "' , '" + deposit.CardNumber + "' , '" + deposit.Type +
							"' , '" + deposit.ClientId + "' , '" + deposit.DateDeposit + "')";
				SqlCmd.ExecuteNonQuery();
				CloseConnection();
				return true;
			}
			return false;
		}
		private static bool CheckPayingCapacity(int depositmoney, int cardmoney)
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
			SqlCmd.CommandText = @"SELECT * FROM deposits WHERE duration = @duration and number = @number 
				and type = @type and client_id = @client_Id";
			SqlCmd.Parameters.Add(new SQLiteParameter("@duration") { Value = deposit.Duration });
			SqlCmd.Parameters.Add(new SQLiteParameter("@number") { Value = deposit.Number });
			SqlCmd.Parameters.Add(new SQLiteParameter("@type") { Value = deposit.Type });
			SqlCmd.Parameters.Add(new SQLiteParameter("@client_Id") { Value = deposit.ClientId });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();

			if (reader.Read())
			{
				deposit = new Deposit(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),reader.GetString(3),
					reader.GetString(4), reader.GetInt32(5), CheckConfirm(reader.GetInt32(6)), Convert.ToDateTime(reader.GetString(7), CultureInfo.CurrentCulture));
				reader.Close();
				CloseConnection();
				return deposit;
			}
			else
			{
				return null;
			}
		}
		public void DeleteSelectedDeposit(int depositId)
		{
			OpenConnection();
			SqlCmd.CommandText = @"DELETE FROM deposits WHERE deposit_id = @smthid";
			SqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = depositId });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
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
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
