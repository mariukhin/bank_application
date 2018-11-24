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
using bank_application.ViewModel;

namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
		ClientViewModel uvm;

		public Registration()
		{
			InitializeComponent();
			uvm = new ClientViewModel();
			DataContext = uvm;
		}
		
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
