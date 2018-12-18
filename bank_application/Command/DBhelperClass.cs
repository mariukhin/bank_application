
using System.Data.SQLite;
using System.Data;

namespace bank_application.Command
{
	public class DBhelperClass
	{
		public string DbFileName { get; set; }
		public SQLiteConnection DbConn { get; set; }
		public SQLiteCommand SqlCmd { get; set; }

		public DBhelperClass() { }

		public void OpenConnection()
		{
			DbFileName = "BankDB.db";
			DbConn = new SQLiteConnection("Data Source=" + DbFileName + ";Version=3;");
			DbConn.Open();
			SqlCmd = new SQLiteCommand
			{
				Connection = DbConn
			};
		}
		public void CloseConnection()
		{
			if (DbConn != null && DbConn.State != ConnectionState.Closed)
			{
				DbConn.Close();
			}
		}
		public static bool CheckConfirm(int confirm)
		{
			return confirm == 1 ? true : false;
		}

	}
}
