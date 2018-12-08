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
        public DepositsPage(ClientViewModel uvm)
        {
            InitializeComponent();
			DataContext = uvm;
		}
		private void btnClickProlongDeposit(object sender, RoutedEventArgs e)
		{
			//проверка возможности продления депозита, если да, то продить, если нет, то ничего не делать
		}
	}
}
