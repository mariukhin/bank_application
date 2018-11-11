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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;
using System.Data;


namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		private string dbFileName;
		private SQLiteConnection m_dbConn;
		private SQLiteCommand m_sqlCmd;
		private Client client;
		private Admin admin;


		public Login()
		{
			InitializeComponent();
		}
		private void btnAuth_Click(object sender, RoutedEventArgs e)
		{
			ConnectToDB();
			if (tbLogin.Text == "admin")
			{
				authAdmin(pbPassword.Password.ToString());
			}
			else
			{
				authUser(tbLogin.Text, pbPassword.Password.ToString());
			}

		}
		private void authUser(string login, string password)
		{
			if (checkUser(login, password) == true)
			{
				MainWindow mainWindow = new MainWindow(client);
				mainWindow.Show();
			}
			else
			{
				MessageBox.Show("Your login or password is invalid! Please try again");
			}
		}
		private void authAdmin(string password)
		{
			if (checkAdmin(password) == true)
			{
				AdminWindow adminWindow = new AdminWindow();
				adminWindow.Show();
			}
			else
			{
				MessageBox.Show("Your login or password is invalid! Please try again");
			}
		}
		private bool checkUser(string login, string password)
		{
			m_sqlCmd.CommandText = @"SELECT * FROM clients WHERE login = @login and password = @password";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@login") { Value = login });
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@password") { Value = password });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			if (reader.Read())
			{
				client = new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
					reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9),
					reader.GetString(10), reader.GetInt32(11), reader.GetInt32(12));
				return true;
			}
			else
			{
				return false;
			}

		}
		private bool checkAdmin(string password)
		{
			m_sqlCmd.CommandText = @"SELECT * FROM admins WHERE password = @password";
			m_sqlCmd.Parameters.Add(new SQLiteParameter("@password") { Value = password });
			m_sqlCmd.ExecuteNonQuery();
			SQLiteDataReader reader;
			reader = m_sqlCmd.ExecuteReader();
			if (reader.Read())
			{
				admin = new Admin(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4),
					reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9));
				MessageBox.Show(admin.ToString());
				return true;
			}
			else
			{
				return false;
			}
		}
		private void btnReg_Click(object sender, RoutedEventArgs e)
		{
			Registration registration = new Registration();
			registration.Show();

		}
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void LoginWindow_Loaded(object sender, RoutedEventArgs e)
		{
			m_dbConn = new SQLiteConnection();
			m_sqlCmd = new SQLiteCommand();

			dbFileName = "BankDB.db";
		}
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
				MessageBox.Show("Disconnected");
				MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}
