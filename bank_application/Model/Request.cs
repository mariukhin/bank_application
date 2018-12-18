using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using bank_application.Command;
using System.Globalization;

namespace bank_application
{
	public class Request : DBhelperClass, INotifyPropertyChanged
	{
		public int Id { get; set; }
		private int clientid;
		private int adminid;
		private int smthid;
		private DateTime date;
		private string description;


		public Request() { }
		public Request(int Id, int ClientId, int AdminId, int SmthId, DateTime Date, string Description)
		{
			this.Id = Id;
			this.ClientId = ClientId;
			this.AdminId = AdminId;
			this.SmthId = SmthId;
			this.Date = Date;
			this.Description = Description;
		}

		public void AddNewRequest(Request request)
		{
			OpenConnection();
			SqlCmd.CommandText = "INSERT INTO requests ('client_id', 'admin_id', 'smth_id', 'date', 'descr') values ('" +
						request.ClientId + "' , '" + request.AdminId + "' , '" + request.SmthId + "','" + 
						request.Date.ToString(CultureInfo.CurrentCulture) + "' , '" + request.Description + "')";
			SqlCmd.ExecuteNonQuery();
			CloseConnection();
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
		public int AdminId
		{
			get { return adminid; }
			set
			{
				adminid = value;
				OnPropertyChanged("AdminId");
			}
		}
		public int SmthId
		{
			get { return smthid; }
			set
			{
				smthid = value;
				OnPropertyChanged("SmthId");
			}
		}
		public DateTime Date
		{
			get { return date; }
			set
			{
				date = value;
				OnPropertyChanged("DateTime");
			}
		}
		public string Description
		{
			get { return description; }
			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
