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
	/// Логика взаимодействия для AdminWindow.xaml
	/// </summary>
	public partial class AdminWindow : Window
	{
		private string dbFileName;
		private SQLiteConnection m_dbConn;
		private SQLiteCommand m_sqlCmd;

		public AdminWindow()
		{
			InitializeComponent();
		}

		private void btnConfirm_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnReject_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void adminWindow_Loaded(object sender, RoutedEventArgs e)
		{
			m_dbConn = new SQLiteConnection();
			m_sqlCmd = new SQLiteCommand();

			dbFileName = "BankDB.db";
		}

		private void btnRefresh_Click(object sender, RoutedEventArgs e)
		{
			DataTable dTable = new DataTable();
			ConnectToDB();
			if (m_dbConn.State != ConnectionState.Open)
			{
				MessageBox.Show("Open connection with database");
				return;
			}

			var sqlCommand = new SQLiteCommand("select * from clients", m_dbConn);
			sqlCommand.ExecuteNonQuery();

			var dataTable = new DataTable("clients");
			var sqlAdapter = new SQLiteDataAdapter(sqlCommand);
			sqlAdapter.Fill(dataTable);

			dgvViewer.ItemsSource = dataTable.DefaultView;
			sqlAdapter.Update(dataTable);
			//try
			//{
			//	sqlQuery = "SELECT * FROM Catalog";
			//	SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, m_dbConn);
			//	adapter.Fill(dTable);

			//	if (dTable.Rows.Count > 0)
			//	{
			//		dgvViewer.Rows.Clear();

			//		for (int i = 0; i < dTable.Rows.Count; i++)
			//			dgvViewer.Rows.Add(dTable.Rows[i].ItemArray);
			//	}
			//	else
			//		MessageBox.Show("Database is empty");
			//}
			//catch (SQLiteException ex)
			//{
			//	MessageBox.Show("Error: " + ex.Message);
			//}
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
		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
