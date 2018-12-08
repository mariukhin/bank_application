using System.Windows;
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
		}
		private void btnClickDeposits(object sender, RoutedEventArgs e)
		{
			Main.Content = new DepositsPage(nuvm);
		}
		private void btnClickMyCards(object sender, RoutedEventArgs e)
		{
			Main.Content = new CardsPage(nuvm);
		}
		private void btnClickCashback(object sender, RoutedEventArgs e)
		{
			Main.Content = new Cashback(nuvm);
		}
		private void btnClickMoneybox(object sender, RoutedEventArgs e)
		{
			Main.Content = new Moneybox();
		}
		private void btnClickPersonalData(object sender, RoutedEventArgs e)
		{
			Main.Content = new PersonalData(nuvm);
		}
		private void btnCloseClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
