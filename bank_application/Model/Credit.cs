using bank_application.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using System;
using System.Globalization;

namespace bank_application
{
    public class Credit : DBhelperClass, INotifyPropertyChanged
	{
		public int Id { get; set; }
		private int duration;
		private int number;
		private string cardnumber;
		private int clientid;
		private bool isconfirmcr;
		private DateTime datecredit;

		public Credit(int Id, int Duration, int Number, string CardNumber, int ClientId, bool IsConfirmCr, DateTime DateCredit)
		{
			this.Id = Id;
			this.ClientId = ClientId;
			this.Duration = Duration;
			this.Number = Number;
			this.CardNumber = CardNumber;
			this.IsConfirmCr = IsConfirmCr;
			this.DateCredit = DateCredit;
		}
		public void AddNewCredit(Credit credit, Card card)
		{
			OpenConnection();
			SqlCmd.CommandText = "INSERT INTO credits ('duration', 'number','cardnumber','client_id','date') values ('" +
						credit.Duration + "' , '" + credit.Number + "' , '" + credit.CardNumber + "' , '" + credit.ClientId + "' , '" + credit.DateCredit +"')";
			SqlCmd.ExecuteNonQuery();
			CloseConnection();
			CheckNewCredits(card, credit);
		}
		public void CheckNewCredits(Card card, Credit credit)
		{
			if (credit.CardNumber.Equals(card.CardNumber, StringComparison.Ordinal))
			{
				int money = card.Money + credit.Number;
				OpenConnection();
				SqlCmd.CommandText = @"UPDATE cards SET money = @money WHERE card_id = @cardid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@money") { Value = money });
				SqlCmd.Parameters.Add(new SQLiteParameter("@cardid") { Value = card.Id });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
				CloseConnection();
			}
		}
		public Credit GetCurrentCredit(Credit credit)
		{
			OpenConnection();
			SqlCmd.CommandText = @"SELECT * FROM credits WHERE duration = @duration and 
				number = @number and cardnumber = @cardnumber and client_id = @client_Id";
			SqlCmd.Parameters.Add(new SQLiteParameter("@duration") { Value = credit.Duration });
			SqlCmd.Parameters.Add(new SQLiteParameter("@number") { Value = credit.Number });
			SqlCmd.Parameters.Add(new SQLiteParameter("@cardnumber") { Value = credit.CardNumber });
			SqlCmd.Parameters.Add(new SQLiteParameter("@client_Id") { Value = credit.ClientId });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();

			if (reader.Read())
			{
				credit = new Credit(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
					reader.GetString(3) ,reader.GetInt32(4), CheckConfirm(reader.GetInt32(5)), Convert.ToDateTime(reader.GetString(6), CultureInfo.CurrentCulture));
				reader.Close();
				CloseConnection();
				return credit;
			}
			else
			{
				return null;
			}
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
		public int ClientId
		{
			get { return clientid; }
			set
			{
				clientid = value;
				OnPropertyChanged("ClientId");
			}
		}
		public bool IsConfirmCr
		{
			get { return isconfirmcr; }
			set
			{
				isconfirmcr = value;
				OnPropertyChanged("IsConfirmCr");
			}
		}
		public DateTime DateCredit
		{
			get { return datecredit; }
			set
			{
				datecredit = value;
				OnPropertyChanged("DateCredit");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
