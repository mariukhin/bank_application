using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace bank_application
{
	public class DbClass
	{
		private string dbFileName;
		private SQLiteConnection m_dbConn;
		private SQLiteCommand m_sqlCmd;



		private void ConnectToDB()
		{
			try
			{
				m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
				m_dbConn.Open();
				m_sqlCmd.Connection = m_dbConn;

			}
			catch (SQLiteException ex)
			{
				//MessageBox.Show("Disconnected");
				//MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}
