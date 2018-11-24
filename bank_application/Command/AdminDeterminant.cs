using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace bank_application.Command
{
	public class AdminDeterminant
	{
		private string dbFileName;
		private SQLiteConnection m_dbConn;
		private SQLiteCommand m_sqlCmd;
		private Admin admin;

		public void OpenConnection()
		{
			dbFileName = "BankDB.db";
			m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
			m_dbConn.Open();
			m_sqlCmd = new SQLiteCommand();
			m_sqlCmd.Connection = m_dbConn;
		}
		public void CloseConnection()
		{
			if (m_dbConn != null && m_dbConn.State != ConnectionState.Closed)
			{
				m_dbConn.Close();
			}
		}
		public bool CheckAdmin(string password)
		{
			if (GetAdmin(password) != null)
			{
				return true;
			}
			return false;
		}
		private Admin GetAdmin(string password)
		{
			OpenConnection();
			m_sqlCmd.CommandText = @"SELECT * FROM admins WHERE password = @password";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@password") { Value = password });
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
	}
}
