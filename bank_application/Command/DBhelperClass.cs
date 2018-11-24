using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using System.Data;

namespace bank_application.Command
{
	public class DBhelperClass
	{
		public string dbFileName;
		public SQLiteConnection m_dbConn;
		public SQLiteCommand m_sqlCmd;

		public DBhelperClass() { }

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
		public bool CheckConfirm(int confirm)
		{
			if (confirm == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}
