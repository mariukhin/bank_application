using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using System.Data;


namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для AddCredit.xaml
	/// </summary>
	public partial class AddCredit : Window
	{
		private string dbFileName;
		private SQLiteConnection m_dbConn;
		private SQLiteCommand m_sqlCmd;
		public AddCredit()
		{
			InitializeComponent();
		}

		private void btnClickAddCredit(object sender, RoutedEventArgs e)
		{
			if (checkBox1.IsChecked == true)
			{
				m_dbConn = new SQLiteConnection();
				m_sqlCmd = new SQLiteCommand();
				dbFileName = "BankDB.db";

			}
			//1)проверка кредита на макс суму
			//2)проверка возможности данного клиента взять кредит

			//Credit credit = new Credit('mmm', Client, 3, 5000);
			Close();
		}
		private void ConnectToDB()
		{
			if (!File.Exists(dbFileName))
				MessageBox.Show("Please, create DB and blank table (Push \"Create\" button)");

			try
			{
				m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
				m_dbConn.Open();
				m_sqlCmd.Connection = m_dbConn;

				MessageBox.Show("Connected");
			}
			catch (SQLiteException ex)
			{
				MessageBox.Show("Disconnected");
				MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}
