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

//запилить поля PassportNum и Adress
namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
		private string dbFileName;
		private SQLiteConnection m_dbConn;
		private SQLiteCommand m_sqlCmd;
		private string Login;

		public Registration()
		{
			InitializeComponent();
		}

		private void regWindow_Loaded(object sender, RoutedEventArgs e)
		{
			m_dbConn = new SQLiteConnection();
			m_sqlCmd = new SQLiteCommand();

			dbFileName = "BankDB.db";
		}
		private void btnComp_Click(object sender, RoutedEventArgs e)
		{
			//1)проверка наличия такого же пользователя в бд
			//2)Валидация всех полей
			if (checkBox1.IsChecked == true)
			{
				Login = tbEmail.Text;
			}
			else
			{
				Login = tbPhone.Text;
			}
			int passNum = Convert.ToInt32(tbPassportNum.Text);
			Client client = new Client(tbFirstName.Text, tbSurName.Text, tbAge.Text,
				tbPassportSeries.Text, passNum, tbAdress.Text, tbEmail.Text, tbPhone.Text, pbPassword.Password.ToString(),Login,0,0);
			addToDB(client);
			Close();
		}
		private void addToDB(Client client)
		{
			ConnectToDB();
			if (m_dbConn.State != ConnectionState.Open)
			{
				MessageBox.Show("Open connection with database");
				return;
			}
			try
			{
				m_sqlCmd.CommandText = "INSERT INTO clients ('first_name', 'last_name', 'dateofbirth', " +
					"'passportseries', 'passportnum', 'adress', 'email','phone', 'login', 'password', 'cashback','moneybox') values ('" +
					client.Firstname + "' , '" + client.Surname + "' , '" + client.DateOfBirth + "', '"+ 
					client.PassportSeries + "', '" + client.PassportNum + "', '" + client.Adress + "', '" + 
					client.Email + "', '" + client.Phonenumber + "', '" + client.Login + "', '" + 
					client.Password + "', '" + client.Cashback + "', '" + client.Moneybox + "')";


				m_sqlCmd.ExecuteNonQuery();
			}
			catch (SQLiteException ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
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

			}
			catch (SQLiteException ex)
			{
				MessageBox.Show("Disconnected");
				MessageBox.Show("Error: " + ex.Message);
			}
		}
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
