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
	/// Логика взаимодействия для AddCredit.xaml
	/// </summary>
	public partial class AddCredit : Window
	{
		public AddCredit()
		{
			InitializeComponent();
		}

		private void btnClickAddCredit(object sender, RoutedEventArgs e)
		{
			//0)Если не нажал на checkbtn1, то гудбай!!))
			//1)проверка кредита на макс суму
			//2)проверка возможности данного клиента взять кредит

			//Credit credit = new Credit('mmm', Client, 3, 5000);
			Close();
		}
	}
}
