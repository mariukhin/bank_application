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
using System.Windows.Navigation;
using bank_application.ViewModel;

namespace bank_application
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
		ClientViewModel nuvm;
        public MainWindow(ClientViewModel uvm)
        {
            InitializeComponent();
			nuvm = uvm;
			DataContext = uvm;
		}

		private void btnClickCredits(object sender, RoutedEventArgs e)
		{
			Main.Content = new CreditsPage(nuvm);
			//Main.NavigationService.Navigate(new Uri("CreditsPage.xaml", UriKind.Relative));
		}
		private void btnClickDeposits(object sender, RoutedEventArgs e)
		{
			Main.Content = new DepositsPage(nuvm);
			//Main.NavigationService.Navigate(new Uri("DepositsPage.xaml", UriKind.Relative));
		}
		private void btnClickMyCards(object sender, RoutedEventArgs e)
		{
			Main.Content = new CardsPage(nuvm);
			//Main.NavigationService.Navigate(new Uri("CardsPage.xaml", UriKind.Relative));
		}
		private void btnClickCashback(object sender, RoutedEventArgs e)
		{
			Main.Content = new Cashback();
			//вернуть поле кешбек клиента 
		}
		private void btnClickMoneybox(object sender, RoutedEventArgs e)
		{
			Main.Content = new Moneybox();
			//вернуть поле копилки клиента
		}
		private void btnClickPersonalData(object sender, RoutedEventArgs e)
		{
			Main.Content = new PersonalData();
			//вернуть функцию личных данных клиента
		}
		private void btnCloseClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
