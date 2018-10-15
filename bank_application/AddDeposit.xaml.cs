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

namespace bank_application
{
	/// <summary>
	/// Логика взаимодействия для AddDeposit.xaml
	/// </summary>
	public partial class AddDeposit : Window
	{
		public AddDeposit()
		{
			InitializeComponent();
		}

		private void btnClickAddDeposit(object sender, RoutedEventArgs e)
		{
			//Проверка наличия других депозитов
			//Deposit deposit = new Deposit();
			Close();
		}
	}
}
