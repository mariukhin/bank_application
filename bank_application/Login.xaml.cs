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

namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		public Login()
		{
			InitializeComponent();
		}
		private void btnAuth_Click(object sender, RoutedEventArgs e)
		{
			if (tbLogin.Text == "admin")
			{
				AdminWindow adminWindow = new AdminWindow();
				adminWindow.Show();
			}
			else
			{
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
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
	}
}
