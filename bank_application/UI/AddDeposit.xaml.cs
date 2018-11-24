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
	/// Логика взаимодействия для AddDeposit.xaml
	/// </summary>
	public partial class AddDeposit : Window
	{
		public AddDeposit(ClientViewModel uvm)
		{
			InitializeComponent();
			DataContext = uvm;
		}

	}
}
