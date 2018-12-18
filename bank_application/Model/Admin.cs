using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Globalization;

namespace bank_application
{
	public class Admin : User
	{
		private ObservableCollection<Request> requests = new ObservableCollection<Request>();

		public Admin(int id, string firstname, string surname, string dateOfBirth, string passportSeries, int passportNum,
			string adress, string email, string phonenumber, string password) : base(id, firstname, surname, dateOfBirth, passportSeries, passportNum, adress, email, phonenumber, password)
		{
			this.Id = id;
			this.Firstname = firstname;
			this.Surname = surname;
			this.DateOfBirth = dateOfBirth;
			this.PassportSeries = passportSeries;
			this.PassportNum = passportNum;
			this.Adress = adress;
			this.Email = email;
			this.Phonenumber = phonenumber;
			this.Password = password;
			
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
			SqlCmd.CommandText = @"SELECT * FROM admins WHERE password = @password";
			SqlCmd.Parameters.Add(new SQLiteParameter("@password") { Value = admin.Password });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
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
		public ObservableCollection<Request> CreateRequests(int adminid)
		{
			OpenConnection();
			SqlCmd.CommandText = @"SELECT * FROM requests WHERE admin_id = @adminId";
			SqlCmd.Parameters.Add(new SQLiteParameter("@adminId") { Value = adminid });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
			while (reader.Read())
			{
				Request requst = new Request(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
					Convert.ToDateTime(reader.GetString(4), CultureInfo.CurrentCulture), reader.GetString(5));
				Requests.Add(requst);
			}
			reader.Close();
			CloseConnection();
			return Requests;
		}
		public void DeleteSelectedItem(string descr, int smthId, int reqId)
		{
			OpenConnection();
			if (descr == null)
			{
				throw new ArgumentNullException(nameof(descr));
			}
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
			DeleteRequest(reqId);
		}
		public void ParseDescription(string descr, int smthId, int reqId)
		{
			OpenConnection();
			if (descr.Contains("credit"))
			{
				SqlCmd.CommandText = @"UPDATE credits SET isConfirm = 1 WHERE credit_id = @smthid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smthId });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (descr.Contains("deposit"))
			{
				SqlCmd.CommandText = @"UPDATE deposits SET isConfirm = 1 WHERE deposit_id = @smthid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smthId });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			else if (descr.Contains("card"))
			{
				SqlCmd.CommandText = @"UPDATE cards SET isConfirm = 1 WHERE card_id = @smthid";
				SqlCmd.Parameters.Add(new SQLiteParameter("@smthid") { Value = smthId });
				SqlCmd.ExecuteNonQuery();
				SQLiteDataReader reader;
				reader = SqlCmd.ExecuteReader();
				reader.Close();
			}
			CloseConnection();
			DeleteRequest(reqId);
		}
		private void DeleteRequest(int req_id)
		{
			OpenConnection();
			SqlCmd.CommandText = @"DELETE FROM requests WHERE request_id = @reqId";
			SqlCmd.Parameters.Add(new SQLiteParameter("@reqId") { Value = req_id });
			SqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = SqlCmd.ExecuteReader();
			reader.Close();
			CloseConnection();
		}

		public ObservableCollection<Request> Requests => requests;
		public void SetRequests(ObservableCollection<Request> value)
		{
			requests = value;
			OnPropertyChanged("Requests");
		}
		public override string ToString()
		{
			return Id + '|' + Email + '|' + Surname + '|' + PassportNum + '|' + Firstname + '|' + DateOfBirth;
		}
	}
}
