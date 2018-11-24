using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using bank_application.ViewModel;


namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для AdminWindow.xaml
	/// </summary>
	public partial class AdminWindow : Window
	{
		AdminViewModel navm;
		public AdminWindow(AdminViewModel avm)
		{
			InitializeComponent();
			navm = avm;
			DataContext = avm;
		}
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void btnRefresh_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}
