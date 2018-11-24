using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace bank_application
{
	public class Admin : User
	{
		private ObservableCollection<Request> requests = new ObservableCollection<Request>();

		public Admin(int Id, string Firstname, string Surname, string DateOfBirth, string PassportSeries, int PassportNum,
			string Adress, string Email, string Phonenumber, string Password) : base(Id, Firstname, Surname, DateOfBirth, PassportSeries, PassportNum, Adress, Email, Phonenumber, Password)
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
			this.Password = Password;
			
		}
		public Admin AuthAdmin(Admin admin)
		{
			Admin newAdmin = CheckAdmin(admin);
			if (newAdmin != null)
			{
				return newAdmin;
			}
			else
			{
				return null;
			}
		}
		private Admin CheckAdmin(Admin admin)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM admins WHERE password = @password";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@password") { Value = admin.Password });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			if (reader.Read())
			{
				admin = new Admin(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
					reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
				reader.Close();
				CloseConnection();
				return admin;
			}
			else
			{
				return null;
			}
		}
		public ObservableCollection<Request> CreateRequests(int admin_id)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM requests WHERE admin_id = @adminId";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@adminId") { Value = admin_id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			while (reader.Read())
			{
				Request requst = new Request(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
					Convert.ToDateTime(reader.GetString(4)), reader.GetString(5));
				Requests.Add(requst);
			}
			reader.Close();
			CloseConnection();
			return Requests;
		}
		public void DeleteSelectedItem(string descr, int smth_id, int req_id)
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
			DeleteRequest(req_id);
		}
		public void ParseDescription(string descr, int smth_id, int req_id)
		{
			OpenConnection();
			if (descr.Contains("credit"))
			{
				m_sqlCmd.CommandText = @"UPDATE credits SET isConfirm = 1 WHERE credit_id = @smthid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smth_id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (descr.Contains("deposit"))
			{
				m_sqlCmd.CommandText = @"UPDATE deposits SET isConfirm = 1 WHERE deposit_id = @smthid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smth_id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (descr.Contains("card"))
			{
				m_sqlCmd.CommandText = @"UPDATE cards SET isConfirm = 1 WHERE card_id = @smthid";
				m_sqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smth_id });
				m_sqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = m_sqlCmd.ExecuteReader();
				reader.Close();
			}
			CloseConnection();
			DeleteRequest(req_id);
		}
		private void DeleteRequest(int req_id)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"DELETE FROM requests WHERE request_id = @reqId";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@reqId") { Value = req_id });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			reader.Close();
			CloseConnection();
		}
		public ObservableCollection<Request> Requests
		{
			get { return requests; }
			set
			{
				requests = value;
				OnPropertyChanged("Requests");
			}
		}
		public override string ToString()
		{
			return Id + '|' + Email + '|' + Surname + '|' + PassportNum + '|' + Firstname + '|' + DateOfBirth;
		}
	}
}
