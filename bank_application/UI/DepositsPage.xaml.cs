using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using bank_application.ViewModel;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для Deposits.xaml
    /// </summary>
    public partial class DepositsPage : Page
    {
		ClientViewModel nuvm;
        public DepositsPage(ClientViewModel uvm)
        {
            InitializeComponent();
			nuvm = uvm;
			DataContext = uvm;
		}
		private void btnClickAddDeposit(object sender, RoutedEventArgs e)
		{
			AddDeposit addDeposit = new AddDeposit(nuvm);
			addDeposit.Show();
		}
		private void btnClickCancelDeposit(object sender, RoutedEventArgs e)
		{
			//проверка возможности удаления, если да, то удалить, если нет, то оставить
		}
		private void btnClickProlongDeposit(object sender, RoutedEventArgs e)
		{
			//проверка возможности продления депозита, если да, то продить, если нет, то ничего не делать
		}
	}
}
