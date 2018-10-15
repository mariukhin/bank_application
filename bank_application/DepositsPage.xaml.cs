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
    /// Логика взаимодействия для Deposits.xaml
    /// </summary>
    public partial class DepositsPage : Page
    {
        public DepositsPage()
        {
            InitializeComponent();
        }
		private void btnClickAddDeposit(object sender, RoutedEventArgs e)
		{
			AddDeposit addDeposit = new AddDeposit();
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
